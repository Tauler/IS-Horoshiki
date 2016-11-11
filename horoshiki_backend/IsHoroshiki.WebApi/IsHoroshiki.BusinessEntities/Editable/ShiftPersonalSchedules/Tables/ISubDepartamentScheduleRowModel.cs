using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка подотдел или должность
    /// В строке может быть заполнено либо отдел, либо должность
    /// </summary>
    public interface ISubDepartamentScheduleRowModel
    {
        /// <summary>
        /// Строка в таблице - подотдел
        /// </summary>
        ISubDepartmentModel SubDepartment
        {
            get;
            set;
        }


        /// <summary>
        /// Строка в таблице - Должность
        /// </summary>
        IPositionModel Position
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