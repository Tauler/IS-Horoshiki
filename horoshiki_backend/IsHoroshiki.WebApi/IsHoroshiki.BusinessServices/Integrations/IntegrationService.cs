using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessEntities.Integrations.MappingDao;
using IsHoroshiki.BusinessServices.Helpers;
using IsHoroshiki.BusinessServices.Integrations.Queues;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Integrations
{
    /// <summary>
    /// Сервис интеграции
    /// </summary>
    public class IntegrationService : IIntegrationService
    {
        #region IIntegrationService

        // <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        public Task<bool> Save(IIntegrationCheckModel model)
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                try
                {
                    var daoEntity = model.ToDaoEntity();

                    daoEntity.DateReceive = DateTime.Now;

                    using (var unit = new UnitOfWork())
                    {
                        unit.IntegrationCheckRepository.Insert(daoEntity);
                        unit.Save();

                        IntegrationCheckQueue.Instance.Enqueue(daoEntity);
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    return false;
                }
            });
        }

        #endregion
    }
}
