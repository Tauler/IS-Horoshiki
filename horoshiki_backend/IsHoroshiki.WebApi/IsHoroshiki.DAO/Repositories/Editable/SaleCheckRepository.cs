using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

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
    }
}
