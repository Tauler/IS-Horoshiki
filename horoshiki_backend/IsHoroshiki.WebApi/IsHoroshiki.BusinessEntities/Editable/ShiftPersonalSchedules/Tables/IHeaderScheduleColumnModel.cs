using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка - Заголовок таблицы (дата)
    /// </summary>
    public interface IHeaderScheduleColumnModel
    {
        /// <summary>
        /// Дата (день недели)
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Описание дня недели
        /// </summary>
        string DayOfWeekDescr
        {
            get;
            set;
        }
    }
}