using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Список смен для сотрудника на дату
    /// </summary>
    public interface IUserShiftTypeColumn
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
        /// Список смен
        /// </summary>
        List<IShiftPersonalScheduleModel> Schedules
        {
            get;
            set;
        }
    }
}