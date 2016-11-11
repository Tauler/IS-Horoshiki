using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// График работы отдела (строка отдел в таблице).
    /// В строке может быть заполнено либо отдел, либо должность
    /// </summary>
    public interface IDepartamentScheduleRowModel
    {
        /// <summary>
        /// Строка в таблице - Отдел
        /// </summary>
        IDepartmentModel DepartmentModel
        {
            get;
            set;
        }


        /// <summary>
        /// Строка в таблице - Должность
        /// </summary>
        IPositionModel PositionModel
        {
            get;
            set;
        }

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