using IsHoroshiki.BusinessServices.Helpers;
using IsHoroshiki.DAO.DaoEntities.Integrations;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;

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

                            //var result = unitOfWork.SaleCheckRepository.GetSaleCheckAnalize(1, new DateTime(2016, 10, 1), new DateTime(2016, 10, 1), 1 == 1);

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
                                    normaCheck.Id = exist.Id;
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

        #endregion
    }
}
