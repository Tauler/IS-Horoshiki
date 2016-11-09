using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Смена работы персонала
    /// </summary>
    public class ShiftPersonalConfiguration : BaseDaoEntityConfiguration<ShiftPersonal>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public ShiftPersonalConfiguration() 
            : base("ShiftPersonals")
        {
            Property(p => p.IsAroundClock)
                .IsRequired();

            Property(p => p.StartTime)
               .IsRequired();

            Property(p => p.StopTime)
               .IsRequired();
        }

        #endregion
    }
}
