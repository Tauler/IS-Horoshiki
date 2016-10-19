using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий План продаж
    /// </summary>
    public class SalePlanRepository : BaseRepository<SalePlan>, ISalePlanRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SalePlanRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
