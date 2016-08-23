using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Типы зон доставки
    /// </summary>
    public class DeliveryZoneConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<DeliveryZone>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryZoneConfiguration() 
            : base(" DeliveryZones")
        {

        }

        #endregion
    }
}
