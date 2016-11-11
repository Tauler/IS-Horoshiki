using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка в таблице - сотрудник
    /// </summary>
    public interface IApplicationUserScheduleRowModel
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
        /// Сотрудник
        /// </summary>
        IApplicationUserSmallModel User
        {
            get;
            set;
        }

        /// <summary>
        /// График периода сотрудника на день (смен)
        /// </summary>
        IShiftPersonalScheduleModel ShiftPersonalSchedule
        {
            get;
            set;
        }
    }
}