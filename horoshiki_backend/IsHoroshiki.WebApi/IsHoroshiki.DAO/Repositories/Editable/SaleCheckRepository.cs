using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Чек продаж
    /// </summary>
    public class SaleCheckRepository : BaseRepository<SaleCheck>, ISaleCheckRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SaleCheckRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region ISaleCheckRepository

        /// <summary>
        /// Найти чек по его Id
        /// </summary>
        /// <param name="idCheck">Id чека</param>
        /// <returns></returns>
        public SaleCheck GetByCheckId(string idCheck)
        {
            return DbSet.FirstOrDefault(check => check.IdCheck == idCheck);
        }

        #endregion
    }
}
