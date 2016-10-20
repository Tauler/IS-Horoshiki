using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessEntities.Integrations.MappingDao;
using IsHoroshiki.DAO.Repositories.Integrations;
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
        public async Task<bool> Save(IIntegrationCheckModel model)
        {
            return await SaveInternal(model);
        }

        #endregion

        #region private

        // <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        public async Task<bool> SaveInternal(IIntegrationCheckModel model)
        {
            try
            {
                var daoEntity = model.ToDaoEntity();
                daoEntity.DateReceive = DateTime.Now;

                using (var unit = new UnitOfWork())
                {
                    unit.IntegrationCheckRepository.Insert(daoEntity);
                    unit.Save();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}
