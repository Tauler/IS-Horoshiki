using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Зоны доставки
    /// </summary>
    public class DeliveryZoneConfiguration : BaseDaoEntityConfiguration<DeliveryZone>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryZoneConfiguration() 
            : base("DeliveryZones")
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);

            Property(p => p.Coordinates)
                .IsRequired();

            HasRequired(s => s.DeliveryZoneType);
            HasRequired(s => s.Platform);
        }

        #endregion
    }
}
