using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Способы покупки
    /// </summary>
    public class BuyProcessRepository : BaseNotEditableRepository<BuyProcess>, IBuyProcessRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public BuyProcessRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
