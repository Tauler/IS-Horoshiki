using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable.Interfaces
{
    /// <summary>
    /// Подразделения
    /// </summary>
    public interface ISubDivisionModel : IBaseBusninessModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Часовой пояс
        /// </summary>
        int Timezone
        {
            get;
            set;
        }

        /// <summary>
        /// Типы цен
        /// </summary>
        int PriceTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Заголовок на сайте
        /// </summary>
        string SiteHeader
        {
            get;
            set;
        }
    }
}
