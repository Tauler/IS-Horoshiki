using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Отделы
    /// </summary>
    public class DepartmentConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<Department>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DepartmentConfiguration() 
            : base("Departments")
        {

        }

        #endregion
    }
}
