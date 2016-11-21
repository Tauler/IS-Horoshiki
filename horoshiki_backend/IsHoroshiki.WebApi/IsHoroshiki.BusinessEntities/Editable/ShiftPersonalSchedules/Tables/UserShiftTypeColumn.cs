using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public class UserShiftTypeColumn : IUserShiftTypeColumn
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
        /// Список смен
        /// </summary>
        public List<IShiftPersonalScheduleModel> Schedules
        {
            get;
            set;
        }
    }
}