using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Модель запроса норма часов за период для пользователя
    /// </summary>
    public interface IShiftPersonalScheduleNormaHourModel
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
        /// Дата начала периода
        /// </summary>
        DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        DateTime DateEnd
        {
            get;
            set;
        }
    }
}