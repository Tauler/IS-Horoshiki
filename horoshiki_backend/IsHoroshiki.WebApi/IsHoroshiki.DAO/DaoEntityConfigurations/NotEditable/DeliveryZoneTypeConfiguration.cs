using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeConfiguration : BaseNotEditableDaoEntityConfiguration<DeliveryZoneType>
    { 
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryZoneTypeConfiguration() 
            : base("DeliveryZoneTypes")
        {
            Property(p => p.Background)
                .IsRequired()
                .HasMaxLength(10);

            Property(p => p.BorderColor)
                .IsRequired()
                .HasMaxLength(10);

            Property(p => p.Opacity)
                .IsRequired();
        }

        #endregion
    }
}
