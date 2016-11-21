using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Таблица планирования работы сотрудников по сменам
    /// </summary>
    public class ShiftPersonalScheduleTableModel : IShiftPersonalScheduleTableModel
    {
        /// <summary>
        /// Строка заголовков - Cтолбцы дат в таблице
        /// </summary>
        public List<IHeaderScheduleColumnModel> HeaderScheduleColumns
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во чеков на этот день из плана продаж (строка чеки в таблице)
        /// </summary>
        public List<ISalePlanCountColumnModel> SalePlanCountColumns
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во сотрудников в смене (итоговая и в разбивке по сменам)
        /// </summary>
        public IShiftCountRow ShiftCountRow
        {
            get;
            set;
        }

        /// <summary>
        /// Должности (сотрудники, строки в таблице)
        /// </summary>
        public List<IPositionScheduleRowModel> PositionScheduleRows
        {
            get;
            set;
        }
    }
}
