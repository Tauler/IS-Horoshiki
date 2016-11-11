using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Курьеры (строка в таблице)
    /// </summary>
    public class CourierScheduleRowModel : ICourierScheduleRowModel
    {
        /// <summary>
        /// Строка в таблице - сотрудники
        /// </summary>
        public List<IApplicationUserScheduleRowModel> UserRows
        {
            get;
            set;
        }
    }
}