using IsHoroshiki.BusinessEntities.Account.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка в таблице - сотрудник
    /// </summary>
    public class UserRowModel : IUserRowModel
    {
        /// <summary>
        /// Сотрудник
        /// </summary>
        public IApplicationUserSmallModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Норма часы для сотрудника за период
        /// </summary>
        public int NormaHourColumn
        {
            get;
            set;
        }

        /// <summary>
        /// Список столбцов расписаний смен
        /// </summary>
        public List<IShiftPersonalScheduleModel> ScheduleColumns
        {
            get;
            set;
        }
    }
}