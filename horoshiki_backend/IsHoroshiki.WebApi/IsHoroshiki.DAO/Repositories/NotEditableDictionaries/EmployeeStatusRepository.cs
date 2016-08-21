using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
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
