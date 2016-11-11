using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка - Заголовок таблицы (дата)
    /// </summary>
    public class HeaderScheduleColumnModel : IHeaderScheduleColumnModel
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
        /// Описание дня недели
        /// </summary>
        public string DayOfWeekDescr
        {
            get;
            set;
        }
    }
}