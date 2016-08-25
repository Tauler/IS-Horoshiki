using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Подразделения
    /// </summary>
    public class SubDivisionRepository : BaseNotEditableDictionaryRepository<SubDivision>, ISubDivisionRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SubDivisionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
