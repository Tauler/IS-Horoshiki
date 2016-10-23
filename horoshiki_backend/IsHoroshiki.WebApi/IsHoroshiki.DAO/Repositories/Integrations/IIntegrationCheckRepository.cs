using IsHoroshiki.DAO.DaoEntities.Integrations;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Integrations
{
    /// <summary>
    /// Репозиторий Получение чеков (заказов) из 1С
    /// </summary>
    public interface IIntegrationCheckRepository : IBaseRepository<IntegrationCheck>
    {
        /// <summary>
        /// Список чеков для нормализации
        /// </summary>
        /// <returns></returns>
        List<IntegrationCheck> GetForNormalization();
    }
}
