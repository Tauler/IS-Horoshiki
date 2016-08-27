using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Подразделения
    /// </summary>
    public class SubDivisionModel : BaseBusninessModel
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
