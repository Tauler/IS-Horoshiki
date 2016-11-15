using IsHoroshiki.BusinessServices.Helpers;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Integrations;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Integrations.Queues
{
    /// <summary>
    /// Очередь чеков для нормализации в БД
    /// </summary>
    public class IntegrationCheckQueue : IIntegrationCheckQueue
    {
        #region поля и свойства

        /// <summary>
        /// Instance
        /// </summary>
        public static readonly IntegrationCheckQueue Instance = new IntegrationCheckQueue();

        /// <summary>
        /// Очередь чеков для нормализации в БД
        /// </summary>
        private static readonly Queue<IntegrationCheck> _queue = new Queue<IntegrationCheck>();

        /// <summary>
        /// Запуск потока нормализации записей в БД
        /// </summary>
        private readonly RecurrentTask _excecuteNormalization;

        /// <summary>
        /// true - идет нормализация потока
        /// </summary>
        private volatile bool _isExecuting;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        private IntegrationCheckQueue()
        {
            _excecuteNormalization = new RecurrentTask(TimeSpan.FromSeconds(10), Execute, "Execute normalization for checks", false);
        }

        #endregion

        #region public методы

        /// <summary>
        /// Загрузить очередь
        /// </summary>
        public void Load()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var list = unitOfWork.IntegrationCheckRepository.GetForNormalization();
                    foreach (var check in list)
                    {
                        Enqueue(check);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }

        /// <summary>
        /// Стартовать очередь
        /// </summary>
        public void Start()
        {
            _excecuteNormalization.Start();
        }

        /// <summary>
        /// Остановить очередь
        /// </summary>
        public void Stop()
        {
            _excecuteNormalization.Stop();
        }

        /// <summary>
        /// Добавить чек в очередь
        /// </summary>
        /// <param name="check">чек</param>
        public void Enqueue(IntegrationCheck check)
        {
            lock (_queue)
            {
                if (check.Cmd.ToUpper() == "order".ToUpper())
                {
                    _queue.Enqueue(check);
                }
            }
        }

        #endregion

        #region private методы

        /// <summary>
        /// Нормализация чека и сохранение в БД
        /// </summary>
        protected async void Execute()
        {
            if (_isExecuting)
            {
                return;
            }
            _isExecuting = true;

            try
            {
                while (_queue.Count > 0)
                {
                    IntegrationCheck check = _queue.Dequeue();

                    using (var unitOfWork = new UnitOfWork())
                    {
                        try
                        {
                            var normalization = new NormalizationCheck(unitOfWork);
                            var normaCheck = await normalization.ExecuteNormalization(check);

                            var statusDelete = "Удален".ToUpper();

                            var exist = unitOfWork.SaleCheckRepository.GetByCheckId(normaCheck.IdCheck);
                            if (exist == null && check.Status.ToUpper() != statusDelete)
                            {
                                unitOfWork.SaleCheckRepository.Insert(normaCheck);
                            }
                            else
                            {
                                if (check.Status.ToUpper() == statusDelete)
                                {
                                    if (exist != null)
                                    {
                                        unitOfWork.SaleCheckRepository.Delete(exist);
                                    }
                                }
                                else
                                {
                                    await UpdateDaoCheck(unitOfWork, normaCheck, exist);

                                    unitOfWork.SaleCheckRepository.Update(exist);
                                }
                            }
                            unitOfWork.Save();

                            check.IsSuccessConvert = true;
                            check.ErrorConvert = string.Empty;
                        }
                        catch (Exception e)
                        {
                            check.IsSuccessConvert = false;
                            check.ErrorConvert = e.Message;
                            Logger.Error(e.Message);
                        }

                        unitOfWork.IntegrationCheckRepository.Update(check);
                        unitOfWork.Save();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
            finally
            {
                _isExecuting = false;
            }
        }

        /// <summary>
        /// Обновить данные по чеку
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="normaCheck">Распарсенный нормализованный чек</param>
        /// <param name="exist">Нормализованный чек из БД</param>
        /// <returns></returns>
        private async Task UpdateDaoCheck(UnitOfWork unitOfWork, SaleCheck normaCheck, SaleCheck exist)
        {
            if (exist == null)
            {
                return;
            }

            exist.BuyProcessId = normaCheck.BuyProcessId;
            if (exist.BuyProcessId.HasValue && exist.BuyProcessId > 0)
            {
                exist.BuyProcess = await unitOfWork.BuyProcessPepository.GetByIdAsync(exist.BuyProcessId.Value);
            }


            exist.SubDepartments = unitOfWork.SaleCheckRepository.GetSubDepartments(exist.Id);
            if (exist.SubDepartments == null)
            {
                exist.SubDepartments = new List<SubDepartment>();
            }

            foreach (var subDepartament in normaCheck.SubDepartments)
            {
                var sd = await unitOfWork.SubDepartmentRepository.GetByIdAsync(subDepartament.Id);
                if (exist.SubDepartments != null && !exist.SubDepartments.Any(sdep => sdep.Id == subDepartament.Id))
                {
                    exist.SubDepartments.Add(sd);
                }
            }

            foreach (var subDepartament in exist.SubDepartments.ToList())
            {
                if (!normaCheck.SubDepartments.Any(sdep => sdep.Id == subDepartament.Id))
                {
                    exist.SubDepartments.Remove(subDepartament);
                }
            }

            exist.PlatformId = normaCheck.PlatformId;
            if (exist.PlatformId > 0)
            {
                exist.Platform = await unitOfWork.PlatformRepository.GetByIdAsync(exist.PlatformId);
            }

            exist.DateDoc = normaCheck.DateDoc;
            exist.IdCheck = normaCheck.IdCheck;
            exist.Sum = normaCheck.Sum;
            exist.PlanCookingStart = normaCheck.PlanCookingStart;
            exist.FactCookingStart = normaCheck.FactCookingStart;
            exist.PlanCookingEnd = normaCheck.PlanCookingEnd;
            exist.FactCookingEnd = normaCheck.FactCookingEnd;
            exist.PlanPackingStart = normaCheck.PlanPackingStart;
            exist.FactPackingStart = normaCheck.FactPackingStart;
            exist.PlanPackingEnd = normaCheck.PlanPackingEnd;
            exist.FactPackingEnd = normaCheck.FactPackingEnd;
            exist.PlanDeliveryStart = normaCheck.PlanDeliveryStart;
            exist.FactDeliveryStart = normaCheck.FactDeliveryStart;
            exist.PlanDeliveryEnd = normaCheck.PlanDeliveryEnd;
            exist.FactDeliveryEnd = normaCheck.FactDeliveryEnd;
        }

        #endregion
    }
}
