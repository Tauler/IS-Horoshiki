using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Подразделения
    /// </summary>
    public class SubdivisionRepository : BaseNotEditableDictionaryRepository<Subdivision>, ISubdivisionRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SubdivisionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
