using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;

namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Зона доставки
    /// </summary>
    public class DeliveryZoneModel : BaseBusninessModel, IDeliveryZoneModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PlatformModel, IPlatformModel>))]
        public IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Типы зон
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<DeliveryZoneTypeModel, IDeliveryZoneTypeModel>))]
        public IDeliveryZoneTypeModel DeliveryZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Координаты зоны
        /// </summary>
        public string Сoordinates
        {
            get;
            set;
        }
    }
}
