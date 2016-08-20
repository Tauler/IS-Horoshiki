using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Типы цен
    /// </summary>
    public class PriceTypeRepository : BaseNotEditableDictionaryRepository<PriceType>
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
