using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class DomaRepository : BaseRepository<Doma>, IDomaRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DomaRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion

        #region IDomaRepository

        /// <summary>
        /// Получить все дома
        /// </summary>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        /// <returns></returns>
        public async Task<IEnumerable<Doma>> GetAllAsync(string query, string regionId, bool withParent = false, int limit = 10)
        {
            var codeId = regionId.Substring(0, 15);

            var list = DbSet.Where(p => p.Code.StartsWith(codeId))
                .Where(p => p.Name.Contains(query))
                .OrderBy(p => p.Name)
                .Take(limit)
                .ToList()
                .AsEnumerable();

            return list;
        }

        #endregion
    }
}
