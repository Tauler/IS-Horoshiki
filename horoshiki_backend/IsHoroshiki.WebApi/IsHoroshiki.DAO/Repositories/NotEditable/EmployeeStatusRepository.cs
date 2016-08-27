using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Статус сотрудника
    /// </summary>
    public class EmployeeStatusRepository : BaseNotEditableDictionaryRepository<EmployeeStatus>, IEmployeeStatusRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public EmployeeStatusRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
