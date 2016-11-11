using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация График периода смен работника
    /// </summary>
    public class ShiftPersonalScheduleConfiguration : BaseDaoEntityConfiguration<ShiftPersonalSchedule>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public ShiftPersonalScheduleConfiguration() 
            : base("ShiftPersonalSchedules")
        {
            HasMany(s => s.ShiftPersonalSchedulePeriods)
               .WithRequired();
        }

        #endregion
    }
}
