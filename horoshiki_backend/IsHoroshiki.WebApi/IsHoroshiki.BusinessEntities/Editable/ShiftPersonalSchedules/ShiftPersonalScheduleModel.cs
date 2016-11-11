using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// График периода сотрудника на день (смен)
    /// </summary>
    public class ShiftPersonalScheduleModel : BaseBusninessModel, IShiftPersonalScheduleModel
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public IApplicationUserModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Дата расписания работы сотрудника
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Расписание работы сотрудника (смены)
        /// </summary>
        public ICollection<IShiftPersonalSchedulePeriodModel> ShiftPersonalSchedulePeriods
        {
            get;
            set;
        }
    }
}