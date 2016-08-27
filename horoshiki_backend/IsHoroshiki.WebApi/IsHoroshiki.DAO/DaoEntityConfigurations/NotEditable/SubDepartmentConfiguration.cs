using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Подотделы
    /// </summary>
    public class SubDepartmentConfiguration : BaseNotEditableDaoEntityConfiguration<SubDepartment>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SubDepartmentConfiguration() 
            : base("SubDepartment")
        {
            HasRequired(s => s.Department);
        }

        #endregion
    }
}
