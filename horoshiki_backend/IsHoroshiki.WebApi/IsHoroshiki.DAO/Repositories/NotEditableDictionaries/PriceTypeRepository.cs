using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
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
