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
            var list = DbSet.Where(p => p.Name.StartsWith(query))
                            .Where(p => p.Code.EndsWith("00000000000"))
                            .OrderBy(p => p.Name)
                            .Take(limit)
                            .ToList()
                            .AsEnumerable();

            return list;
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

            var list = DbSet.Where(p => p.Name.StartsWith(query))
                .Where(p => p.Code.StartsWith(codeId))
                .Where(p => p.Code.EndsWith("00000000"))
                .OrderBy(p => p.Name)
                .Take(limit)
                .ToList()
                .AsEnumerable();

            return list;
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

            var list = DbSet.Where(p => p.Name.StartsWith(query))
                .Where(p => p.Code.StartsWith(codeId))
                .Where(p => p.Code.EndsWith("00000"))
                .OrderBy(p => p.Name)
                .Take(limit)
                .ToList()
                .AsEnumerable();

            return list;
        }

        #endregion
    }
}
