using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка в таблице - сотрудник
    /// </summary>
    public interface IUserRowModel
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        IApplicationUserSmallModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Норма часы для сотрудника за период
        /// </summary>
        int NormaHourColumn
        {
            get;
            set;
        }

        /// <summary>
        /// Список смен
        /// </summary>
        List<IUserShiftTypeColumn> UserShiftTypeColumns
        {
            get;
            set;
        }
    }
}