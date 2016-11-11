using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Период для графика смен сотрудника
    /// </summary>
    public class ShiftPersonalSchedulePeriodModel : BaseBusninessModel, IShiftPersonalSchedulePeriodModel
    {
        /// <summary>
        /// График периода смен работника
        /// </summary>
        public IShiftPersonalScheduleModel ShiftPersonalSchedule
        {
            get;
            set;
        }

        ///// <summary>
        ///// Тип смены
        ///// </summary>
        //public IShiftTypeModel ShiftType
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Начало работы
        /// </summary>
        public TimeSpan StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        public TimeSpan StopTime
        {
            get;
            set;
        }
    }
}