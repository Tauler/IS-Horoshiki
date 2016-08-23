using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
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
