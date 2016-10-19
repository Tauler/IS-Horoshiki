using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Сформированый план продаж
    /// </summary>
    public class SalePlanResult
    {
        /// <summary>
        /// Строка отчета
        /// </summary>
        public List<SalePlanRow> Rows
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Строка плана
    /// </summary>
    public class SalePlanRow
    {
        /// <summary>
        /// План на месяц (который редактируется)
        /// </summary>
        public SalePlanDay Plan
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 1
        /// </summary>
        public SalePlanDay Analize1
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 2
        /// </summary>
        public SalePlanDay Analize2
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Сумма чеков на день
    /// </summary>
    public class SalePlanDay
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
