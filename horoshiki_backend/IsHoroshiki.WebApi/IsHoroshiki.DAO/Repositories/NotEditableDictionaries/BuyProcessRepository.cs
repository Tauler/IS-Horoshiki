using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Способы покупки
    /// </summary>
    public class BuyProcessRepository : BaseNotEditableDictionaryRepository<BuyProcess>
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
