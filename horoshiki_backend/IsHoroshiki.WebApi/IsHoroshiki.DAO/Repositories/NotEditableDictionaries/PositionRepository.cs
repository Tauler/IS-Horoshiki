using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Должности
    /// </summary>
    public class PositionRepository : BaseNotEditableDictionaryRepository<Position>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
