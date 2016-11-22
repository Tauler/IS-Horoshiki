using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Модель запроса норма часов за период для пользователя
    /// </summary>
    public class ShiftPersonalScheduleNormaHourModel : IShiftPersonalScheduleNormaHourModel
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
        /// Дата начала периода
        /// </summary>
        public DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        public DateTime DateEnd
        {
            get;
            set;
        }
    }
}