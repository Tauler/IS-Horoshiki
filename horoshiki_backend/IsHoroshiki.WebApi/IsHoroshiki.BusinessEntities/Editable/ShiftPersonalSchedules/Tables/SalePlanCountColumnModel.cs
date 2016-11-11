using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка таблицы Кол-во чеков на этот день из плана продаж
    /// </summary>
    public class SalePlanCountColumnModel : ISalePlanCountColumnModel
    {
        /// <summary>
        /// Дата (день недели)
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во чеков
        /// </summary>
        public int Count
        {
            get;
            set;
        }
    }
}