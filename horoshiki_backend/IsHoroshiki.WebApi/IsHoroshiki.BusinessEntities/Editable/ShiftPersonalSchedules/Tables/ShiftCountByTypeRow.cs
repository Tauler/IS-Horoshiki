using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public class ShiftCountByTypeRow : IShiftCountByTypeRow
    {
        /// <summary>
        /// Тип смены
        /// </summary>
        public IShiftTypeModel ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Всего кол-во сотрудников в смене на этот день
        /// </summary>
        public List<IShiftCountByTypeColumn> ShiftCountByTypeColumns
        {
            get;
            set;
        }
    }
}