using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Таблица планирования работы сотрудников по сменам за период
    /// </summary>
    public interface IShiftPersonalScheduleTableModel
    {
        /// <summary>
        /// Строка заголовков - Cтолбцы дат в таблице
        /// </summary>
        List<IHeaderScheduleColumnModel> HeaderScheduleColumns
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во чеков на этот день из плана продаж (строка чеки в таблице)
        /// </summary>
        List<ISalePlanCountColumnModel> SalePlanCountColumns
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во сотрудников в смене (итоговая и в разбивке по сменам)
        /// </summary>
        IShiftCountRow ShiftCountRow
        {
            get;
            set;
        }

        /// <summary>
        /// Должности (сотрудники, строки в таблице)
        /// </summary>
        List<IPositionScheduleRowModel> PositionScheduleRows
        {
            get;
            set;
        }
    }
}
