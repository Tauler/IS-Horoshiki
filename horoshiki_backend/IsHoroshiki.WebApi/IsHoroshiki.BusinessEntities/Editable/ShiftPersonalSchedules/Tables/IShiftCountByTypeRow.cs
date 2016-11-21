using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public interface IShiftCountByTypeRow
    {
        /// <summary>
        /// Тип смены
        /// </summary>
        IShiftTypeModel ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Всего кол-во сотрудников в смене на этот день
        /// </summary>
        List<IShiftCountByTypeColumn> ShiftCountByTypeColumns
        {
            get;
            set;
        }
    }
}