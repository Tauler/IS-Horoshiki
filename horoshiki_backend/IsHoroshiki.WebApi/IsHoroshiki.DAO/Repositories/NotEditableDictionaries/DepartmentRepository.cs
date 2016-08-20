using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Отделы
    /// </summary>
    public class DepartmentRepository : BaseNotEditableDictionaryRepository<Department>
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
