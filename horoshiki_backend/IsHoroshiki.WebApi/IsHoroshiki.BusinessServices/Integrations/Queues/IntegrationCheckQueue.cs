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
        /// UnitOfWork
        /// </summary>
        private UnitOfWork _unitOfWork = new UnitOfWork();

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
            _excecuteNormalization = new RecurrentTask(TimeSpan.FromSeconds(30), Execute, "Execute normalization for checks", false);
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
                var list = _unitOfWork.IntegrationCheckRepository.GetForNormalization();
                foreach (var check in list)
                {
                    Enqueue(check);
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
                _queue.Enqueue(check);
            }
        }

        #endregion

        #region private методы

        /// <summary>
        /// Нормализация чека и сохранение в БД
        /// </summary>
        protected async void Execute()
        {
            try
            {
                if (_isExecuting)
                {
                    return;
                }
                _isExecuting = true;

                while (_queue.Count > 0)
                {
                    IntegrationCheck check = _queue.Dequeue();

                    try
                    {
                        var normalization = new NormalizationCheck(_unitOfWork);
                        var normaCheck = await normalization.ExecuteNormalization(check);

                        var exist = _unitOfWork.SaleCheckRepository.GetByCheckId(normaCheck.IdCheck);
                        if (exist == null && check.Status.ToUpper() != "Удален".ToUpper())
                        {
                            _unitOfWork.SaleCheckRepository.Insert(normaCheck);
                        }
                        else
                        {
                            if (check.Status.ToUpper() == "Удален".ToUpper())
                            {
                                _unitOfWork.SaleCheckRepository.Delete(exist);
                            }
                            else
                            {
                                normaCheck.Id = exist.Id;
                                _unitOfWork.SaleCheckRepository.Update(exist);
                            }
                        }
                        _unitOfWork.Save();

                        check.IsSuccessConvert = true;
                        check.ErrorConvert = string.Empty;
                    }
                    catch (Exception e)
                    {
                        check.IsSuccessConvert = false;
                        check.ErrorConvert = e.Message;
                        Logger.Error(e.Message);
                    }

                    _unitOfWork.IntegrationCheckRepository.Update(check);
                    _unitOfWork.Save();
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
