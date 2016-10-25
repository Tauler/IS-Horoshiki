using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// День плана продаж
    /// </summary>
    public class SalePlanDay : BaseDaoEntity
    {
        /// <summary>
        /// План продаж
        /// </summary>
        public int SalePlanId
        {
            get;
            set;
        }

        /// <summary>
        /// План продаж
        /// </summary>
        public SalePlan SalePlan
        {
            get;
            set;
        }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Доставка
        /// </summary>
        public int Delivery
        {
            get;
            set;
        }

        /// <summary>
        /// Cамовывоз
        /// </summary>
        public int Self
        {
            get;
            set;
        }
    }
}
