using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Статус сотрудника
    /// </summary>
    public class EmployeeStatusConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<EmployeeStatus>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public EmployeeStatusConfiguration() 
            : base("EmployeeStatuses")
        {

        }

        #endregion
    }
}
