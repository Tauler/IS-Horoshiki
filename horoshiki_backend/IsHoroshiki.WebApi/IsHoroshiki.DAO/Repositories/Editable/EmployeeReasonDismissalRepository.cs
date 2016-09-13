using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissalRepository : BaseRepository<EmployeeReasonDismissal>, IEmployeeReasonDismissalRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public EmployeeReasonDismissalRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
