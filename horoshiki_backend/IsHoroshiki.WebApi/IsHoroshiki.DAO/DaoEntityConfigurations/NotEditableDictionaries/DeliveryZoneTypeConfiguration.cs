using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<DeliveryZoneType>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryZoneTypeConfiguration() 
            : base(" DeliveryZoneTypes")
        {

        }

        #endregion
    }
}
