using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Период для графика смен работника
    /// </summary>
    public class ShiftPersonalSchedulePeriodConfiguration : BaseDaoEntityConfiguration<ShiftPersonalSchedulePeriod>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public ShiftPersonalSchedulePeriodConfiguration() 
            : base("ShiftPersonalSchedulePeriods")
        {
            Property(p => p.StartTime)
               .IsRequired();

            Property(p => p.StopTime)
               .IsRequired();
        }

        #endregion
    }
}
