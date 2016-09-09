using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.Kladr.Repositories.Interfaces
{
    /// <summary>
    /// Репозитарий Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
    /// </summary>
    public interface IStreetRepository : IBaseRepository<Street>
    {
        /// <summary>
        /// Получить все улицы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<Street>> GetAllAsync(string query, string regionId, bool withParent = false, int limit = 10);
    }
}
