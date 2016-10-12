using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Drawing;

namespace IsHoroshiki.BusinessEntities.NotEditable
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeModel : BaseNotEditableModel, IDeliveryZoneTypeModel
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        public int Time
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет заливки 
        /// </summary>
        public string Background
        {
            get;
            set;
        }

        /// <summary>
        /// Прозрачность заливки 
        /// </summary>
        public float Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет контура 
        /// </summary>
        public string BorderColor
        {
            get;
            set;
        }
    }
}
