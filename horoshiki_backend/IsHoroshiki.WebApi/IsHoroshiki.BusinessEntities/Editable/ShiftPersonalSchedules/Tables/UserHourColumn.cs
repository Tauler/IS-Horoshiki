using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Сумма часов работы для сотрудника на этот день (сколько часов работает в этот день)
    /// </summary>
    public class UserHourColumn : IUserHourColumn
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
        /// Часы работы сотрудника (сколько работает в этот день)
        /// </summary>
        public int SumHour
        {
            get;
            set;
        }
    }
}