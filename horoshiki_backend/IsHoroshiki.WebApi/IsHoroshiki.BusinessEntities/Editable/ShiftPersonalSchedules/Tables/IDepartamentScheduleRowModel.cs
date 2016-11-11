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
        IDepartmentModel Department
        {
            get;
            set;
        }

        /// <summary>
        /// Строка в таблице - подотдел или должность
        /// </summary>
        List<ISubDepartamentScheduleRowModel> SubDepartment
        {
            get;
            set;
        }        
    }
}