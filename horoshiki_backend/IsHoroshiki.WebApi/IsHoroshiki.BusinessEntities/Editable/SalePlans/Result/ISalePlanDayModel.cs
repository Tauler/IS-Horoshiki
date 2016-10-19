using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Сумма чеков на день
    /// </summary>
    public interface ISalePlanDayModel 
    {
        /// <summary>
        /// Дата
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// День недели
        /// </summary>
        DayOfWeek DayOfWeek
        {
            get;
            set;
        }

        /// <summary>
        /// День недели
        /// </summary>
        string DayOfWeekDescr
        {
            get;
            set;
        }

        /// <summary>
        /// Доставка
        /// </summary>
        int Delivery
        {
            get;
            set;
        }

        /// <summary>
        /// Cамовывоз
        /// </summary>
        int Self
        {
            get;
            set;
        }

        /// <summary>
        /// Итого
        /// </summary>
        int Sum
        {
            get;
        }
    }
}
