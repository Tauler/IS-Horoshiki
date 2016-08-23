using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZoneModel : BaseNotEditableDictionaryModel, IDeliveryZoneModel
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        public int Time
        {
            get;
            set;
        }
    }
}
