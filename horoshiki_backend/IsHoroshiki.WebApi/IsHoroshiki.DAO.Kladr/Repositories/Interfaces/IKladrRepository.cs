using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Kladr.Repositories.Interfaces
{
    /// <summary>
    /// Репозитарий Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
    /// </summary>
    public interface IKladrRepository : IBaseRepository<DaoEntities.Kladr>
    {
        /// <summary>
        /// Получить все регионы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetRegionAllAsync(string query, int limit = 10);

        /// <summary>
        /// Получить все районы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetDistrictAllAsync(string query, string regionId, bool withParent = false, int limit = 10);

        /// <summary>
        /// Получить все районы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetCityAllAsync(string query, string regionId, bool withParent = false, int limit = 10);

        /// <summary>
        /// Получить все поселки
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetLocationAllAsync(string query, string regionId, bool withParent = false, int limit = 10);
    }
}
