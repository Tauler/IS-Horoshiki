using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Подотделы
    /// </summary>
    public class SubDepartmentConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<SubDepartment>
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
