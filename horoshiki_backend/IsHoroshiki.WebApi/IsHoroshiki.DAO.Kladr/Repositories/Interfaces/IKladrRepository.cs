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
        /// Получить объект КЛАДРа по коду
        /// </summary>
        /// <param name="code">Код</param>
        /// <returns></returns>
        Task<DaoEntities.Kladr> GetByCode(string code);

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
        /// Получить все поселки\города по региону
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetCityAllByRegionAsync(string query, string regionId, bool withParent = false, int limit = 10);

        /// <summary>
        /// Получить все поселки\города по району
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        Task<IEnumerable<DaoEntities.Kladr>> GetCityAllByDistrictAsync(string query, string regionId, bool withParent = false, int limit = 10);
    }
}
