using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public class ShiftCountRow : IShiftCountRow
    {
        /// <summary>
        /// Кол-во сотрудников по типам смен (строки типы смен)
        /// </summary>
        public List<IShiftCountByTypeRow> ShiftCountByTypeRows
        {
            get;
            set;
        }

        /// <summary>
        /// Всего кол-во сотрудников в смене на этот день (по всем сменам)
        /// </summary>
        public List<IShiftCountResultColumn> ShiftCountResultColumn
        {
            get;
            set;
        }
    }
}