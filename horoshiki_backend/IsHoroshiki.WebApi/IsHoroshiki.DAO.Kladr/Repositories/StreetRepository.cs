using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
    /// </summary>
    public class StreetRepository : BaseRepository<Street>, IStreetRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public StreetRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion

        #region IStreetRepository

        /// <summary>
        /// Получить улицу по коду КЛАДР
        /// </summary>
        /// <param name="regionId">Код кладра</param>
        public async Task<Street> GetByCode(string code)
        {
            return DbSet.FirstOrDefault(s => s.Code == code);
        }

        /// <summary>
        /// Получить все районы
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<Street>> GetAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var codeRegionId = regionId.Substring(0, 2);
            var codeId = regionId.Substring(0, 11);

            IQueryable<Street> queryResult;
            if (!string.IsNullOrEmpty(query))
            {
                queryResult = DbSet.Where(p => p.CodeRegion == codeRegionId && p.CodeQuick == codeId && p.Name.StartsWith(query));
            }
            else
            {
                queryResult = DbSet.Where(p => p.CodeRegion == codeRegionId && p.CodeQuick == codeId);
            }

            queryResult = queryResult.OrderBy(p => p.Name)
                   .Take(limit);

            return queryResult.ToList()
                .AsEnumerable();            
        }

        #endregion
    }
}
