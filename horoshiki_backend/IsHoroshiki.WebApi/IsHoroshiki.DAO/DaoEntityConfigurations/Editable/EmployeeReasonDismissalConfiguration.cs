using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Причины увольнения сотрудника
    /// </summary>
    public class EmployeeReasonDismissalConfiguration : BaseDaoEntityConfiguration<EmployeeReasonDismissal>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public EmployeeReasonDismissalConfiguration() 
            : base("EmployeeReasonDismissals")
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
        }

        #endregion
    }
}
