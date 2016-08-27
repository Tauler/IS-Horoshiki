using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Типы цен
    /// </summary>
    public class PriceTypeRepository : BaseNotEditableDictionaryRepository<PriceType>, IPriceTypeRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PriceTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
