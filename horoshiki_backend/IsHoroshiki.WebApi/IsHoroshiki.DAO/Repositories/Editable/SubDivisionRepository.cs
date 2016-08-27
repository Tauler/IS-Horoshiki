using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Подразделения
    /// </summary>
    public class SubDivisionRepository : BaseRepository<SubDivision>, ISubDivisionRepository
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
