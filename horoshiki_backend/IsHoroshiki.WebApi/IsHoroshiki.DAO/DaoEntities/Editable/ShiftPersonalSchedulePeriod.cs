using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Период для графика смен сотрудника
    /// </summary>
    public class ShiftPersonalSchedulePeriod : BaseDaoEntity
    {
        /// <summary>
        ///  График периода смен работника
        /// </summary>
        public ShiftPersonalSchedule ShiftPersonalSchedule
        {
            get;
            set;
        }

        /// <summary>
        ///  График периода смен работника
        /// </summary>
        public int ShiftPersonalScheduleId
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        public ShiftType ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        public int ShiftTypeId
        {
            get;
            set;
        }

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
