using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans
{
    /// <summary>
    /// Сумма чеков на день
    /// </summary>
    public class SalePlanDayModel : BaseBusninessModel, ISalePlanDayModel
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// День недели
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get;
            set;
        }

        /// <summary>
        /// День недели
        /// </summary>
        public string DayOfWeekDescr
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

        /// <summary>
        /// Итого
        /// </summary>
        public int Sum
        {
            get
            {
                return Delivery + Self;
            }
        }
    }
}
