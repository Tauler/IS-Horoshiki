using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Подразделения
    /// </summary>
    public class SubDivision : BaseDaoEntity
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
        /// Типы цен
        /// </summary>
        public PriceType PriceType
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
