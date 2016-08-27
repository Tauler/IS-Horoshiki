using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Отделы
    /// </summary>
    public class DepartmentConfiguration : BaseNotEditableDaoEntityConfiguration<Department>
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
