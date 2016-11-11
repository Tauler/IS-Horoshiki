using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Планированиe графика работы сотрудников на период
    /// </summary>
    public interface IShiftPersonalScheduleModel : IBaseBusninessModel
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        IApplicationUserModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Дата расписания работы сотрудника
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }


        /// <summary>
        /// Расписание работы сотрудника (смены)
        /// </summary>
        ICollection<IShiftPersonalSchedulePeriodModel> ShiftPersonalSchedulePeriods
        {
            get;
            set;
        }
    }
}