using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Отделы
    /// </summary>
    public class DepartmentRepository : BaseNotEditableDictionaryRepository<Department>, IDepartmentRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DepartmentRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
