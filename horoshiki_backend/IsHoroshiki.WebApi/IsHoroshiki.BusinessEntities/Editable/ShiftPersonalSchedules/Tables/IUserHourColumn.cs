using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Сумма часов работы для сотрудника на этот день (сколько часов работает в этот день)
    /// </summary>
    public interface IUserHourColumn
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
        /// Часы работы сотрудника (сколько работает в этот день)
        /// </summary>
        int SumHour
        {
            get;
            set;
        }
    }
}