using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;

namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Подразделения
    /// </summary>
    public class SubDivisionModel : BaseBusninessModel, ISubDivisionModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Часовой пояс
        /// </summary>
        public int Timezone
        {
            get;
            set;
        }

        /// <summary>
        /// Типы цен
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PriceTypeModel, IPriceTypeModel>))]
        public IPriceTypeModel PriceTypeModel
        {
            get;
            set;
        }

        /// <summary>
        /// Заголовок на сайте
        /// </summary>
        public string SiteHeader
        {
            get;
            set;
        }
    }
}
