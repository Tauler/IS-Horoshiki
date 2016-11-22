using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Обновление смен для пользователя на дату
    /// </summary>
    public interface IShiftPersonalScheduleUpdateModel
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
        /// Дата
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Список смен 
        /// </summary>
        ICollection<IShiftPersonalScheduleModel> ShiftPersonalSchedules
        {
            get;
            set;
        }
    }
}