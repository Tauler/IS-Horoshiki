using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditable
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZoneModel : BaseNotEditableModel, IDeliveryZoneModel
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
