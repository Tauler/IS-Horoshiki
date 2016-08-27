using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Типы зон доставки
    /// </summary>
    public class DeliveryZoneConfiguration : BaseNotEditableDaoEntityConfiguration<DeliveryZone>
    { 
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryZoneConfiguration() 
            : base("DeliveryZones")
        {

        }

        #endregion
    }
}
