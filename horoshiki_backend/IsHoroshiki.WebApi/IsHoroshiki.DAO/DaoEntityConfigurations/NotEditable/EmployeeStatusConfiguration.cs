using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Статус сотрудника
    /// </summary>
    public class EmployeeStatusConfiguration : BaseNotEditableDaoEntityConfiguration<EmployeeStatus>
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
