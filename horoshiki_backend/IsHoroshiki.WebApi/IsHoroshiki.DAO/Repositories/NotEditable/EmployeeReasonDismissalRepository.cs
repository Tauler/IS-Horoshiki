using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissalRepository : BaseNotEditableRepository<EmployeeReasonDismissal>, IEmployeeReasonDismissalRepository
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
