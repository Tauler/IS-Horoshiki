using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
    /// </summary>
    public class KladrRepository : BaseRepository<DaoEntities.Kladr>, IKladrRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public KladrRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion

        #region IKladrRepository

        /// <summary>
        /// Получить все регионы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<DaoEntities.Kladr>> GetRegionAllAsync(string query, int limit = 10)
        {
            IQueryable<DaoEntities.Kladr> queryResult;
            if (!string.IsNullOrEmpty(query))
            {
                queryResult = DbSet.Where(p => p.CodeRegion != null && p.Name.StartsWith(query));
            }
            else
            {
                queryResult = DbSet.Where(p => p.CodeRegion != null);
            }

            queryResult.OrderBy(p => p.Name)
                   .Take(limit);

            return queryResult.ToList()
                   .AsEnumerable();
        }

        /// <summary>
        /// Получить все районы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<DaoEntities.Kladr>> GetDistrictAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var codeId = regionId.Substring(0, 2);

            IQueryable<DaoEntities.Kladr> queryResult;
            if (!string.IsNullOrEmpty(query))
            {
                queryResult = DbSet.Where(p => p.CodeRegion != null 
                                                        && p.CodeRegion == codeId
                                                        && p.CodeDistrict != null 
                                                        && p.Name.StartsWith(query));
            }
            else
            {
                queryResult = DbSet.Where(p => p.CodeRegion != null
                                                        && p.CodeRegion == codeId
                                                        && p.CodeDistrict != null);
            }

            queryResult.OrderBy(p => p.Name)
                   .Take(limit);

            return queryResult.ToList()
                   .AsEnumerable();
        }

        /// <summary>
        /// Получить все районы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<DaoEntities.Kladr>> GetCityAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var codeId = regionId.Substring(0, 5);

            IQueryable<DaoEntities.Kladr> queryResult;
            if (!string.IsNullOrEmpty(query))
            {
                queryResult = DbSet.Where(p => p.CodeDistrict != null 
                                                    && p.CodeDistrict == codeId 
                                                    && p.CodeCity != null 
                                                    && p.Name.StartsWith(query));
            }
            else
            {
                queryResult = DbSet.Where(p => p.CodeDistrict != null 
                                                    && p.CodeDistrict == codeId
                                                    && p.CodeCity != null);
            }

            queryResult.OrderBy(p => p.Name)
                   .Take(limit);

            return queryResult.ToList()
                   .AsEnumerable();
        }

        /// <summary>
        /// Получить все поселки
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<DaoEntities.Kladr>> GetLocationAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var codeId = regionId.Substring(0, 5);

            IQueryable<DaoEntities.Kladr> queryResult;
            if (!string.IsNullOrEmpty(query))
            {
                queryResult = DbSet.Where(p => p.CodeDistrict != null
                                                    && p.CodeDistrict == codeId
                                                    && p.CodeLocality != null
                                                    && p.Name.StartsWith(query));
            }
            else
            {
                queryResult = DbSet.Where(p => p.CodeDistrict != null
                                                    && p.CodeDistrict == codeId
                                                    && p.CodeLocality != null);
            }

            queryResult.OrderBy(p => p.Name)
                   .Take(limit);

            return queryResult.ToList()
                   .AsEnumerable();
        }

        #endregion
    }
}
