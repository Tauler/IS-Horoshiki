using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Период для графика смен сотрудника
    /// </summary>
    public interface IShiftPersonalSchedulePeriodModel : IBaseBusninessModel
    {
        /// <summary>
        /// График периода смен работника
        /// </summary>
        IShiftPersonalScheduleModel ShiftPersonalSchedule
        {
            get;
            set;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        TimeSpan StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        TimeSpan StopTime
        {
            get;
            set;
        }
    }
}