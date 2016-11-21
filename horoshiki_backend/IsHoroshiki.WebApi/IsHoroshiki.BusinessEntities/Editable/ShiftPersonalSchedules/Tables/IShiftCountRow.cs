using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public interface IShiftCountRow
    {
        /// <summary>
        /// Кол-во сотрудников по типам смен (строки типы смен)
        /// </summary>
        List<IShiftCountByTypeRow> ShiftCountByTypeRows
        {
            get;
            set;
        }

        /// <summary>
        /// Всего кол-во сотрудников в смене на этот день (по всем сменам)
        /// </summary>
        List<IShiftCountResultColumn> ShiftCountResultColumn
        {
            get;
            set;
        }
    }
}