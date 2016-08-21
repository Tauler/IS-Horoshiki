using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Должности
    /// </summary>
    public class PositionRepository : BaseNotEditableDictionaryRepository<Position>, IPositionRepository
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
