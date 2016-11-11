using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Курьеры (строка в таблице)
    /// </summary>
    public interface ICourierScheduleRowModel
    {
        /// <summary>
        /// Строка в таблице - сотрудники
        /// </summary>
        List<IApplicationUserScheduleRowModel> UserRows
        {
            get;
            set;
        }
    }
}