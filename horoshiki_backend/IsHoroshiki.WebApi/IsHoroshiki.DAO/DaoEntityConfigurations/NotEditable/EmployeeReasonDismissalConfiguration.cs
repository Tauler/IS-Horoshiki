using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissalConfiguration : BaseNotEditableDaoEntityConfiguration<EmployeeReasonDismissal>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public EmployeeReasonDismissalConfiguration() 
            : base("EmployeeReasonDismissals")
        {

        }

        #endregion
    }
}
