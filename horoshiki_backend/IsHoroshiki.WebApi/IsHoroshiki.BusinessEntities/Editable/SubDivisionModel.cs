using IsHoroshiki.BusinessEntities.Editable.Interfaces;

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
        public int PriceTypeId
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
