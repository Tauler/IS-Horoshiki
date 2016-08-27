using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Подотделы
    /// </summary>
    public class SubDepartmentRepository : BaseNotEditableDictionaryRepository<SubDepartment>, ISubDepartmentRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SubDepartmentRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
