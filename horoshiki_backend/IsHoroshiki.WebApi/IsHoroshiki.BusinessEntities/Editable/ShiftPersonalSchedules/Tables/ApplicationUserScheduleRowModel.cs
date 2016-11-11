using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка в таблице - сотрудник
    /// </summary>
    public class ApplicationUserScheduleRowModel : IApplicationUserScheduleRowModel
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
        /// Сотрудник
        /// </summary>
        public IApplicationUserSmallModel User
        {
            get;
            set;
        }

        /// <summary>
        /// График периода сотрудника на день (смен)
        /// </summary>
        public IShiftPersonalScheduleModel ShiftPersonalSchedule
        {
            get;
            set;
        }
    }
}