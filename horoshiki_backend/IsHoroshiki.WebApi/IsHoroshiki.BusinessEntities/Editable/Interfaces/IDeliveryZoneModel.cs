using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable.Interfaces
{
    /// <summary>
    /// Зона доставки
    /// </summary>
    public interface IDeliveryZoneModel : IBaseBusninessModel
    {
        /// <summary>
        /// Типы зон
        /// </summary>
        IDeliveryZoneTypeModel DeliveryZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Координаты зоны
        /// </summary>
        string Сoordinates
        {
            get;
            set;
        }
    }
}
