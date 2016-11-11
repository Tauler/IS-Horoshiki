using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// График работы отдела (строка отдел в таблице).
    /// В строке может быть заполнено либо отдел, либо должность
    /// </summary>
    public class DepartamentScheduleRowModel : IDepartamentScheduleRowModel
    {
        /// <summary>
        /// Строка в таблице - Отдел
        /// </summary>
        public IDepartmentModel Department
        {
            get;
            set;
        }

        /// <summary>
        /// Строка в таблице - подотдел или должность
        /// </summary>
        public List<ISubDepartamentScheduleRowModel> SubDepartment
        {
            get;
            set;
        }
    }
}