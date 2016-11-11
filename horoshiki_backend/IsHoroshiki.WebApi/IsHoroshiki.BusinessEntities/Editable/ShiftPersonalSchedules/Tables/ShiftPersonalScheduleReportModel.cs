using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Таблица планировани работы сотрудников по сменам
    /// </summary>
    public class ShiftPersonalScheduleReportModel : IShiftPersonalScheduleReportModel
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
        /// График работы отдела (строка отдел в таблице).
        /// </summary>
        public List<IDepartamentScheduleRowModel> DepartamentScheduleRows
        {
            get;
            set;
        }

        /// <summary>
        /// Курьеры (строка Курьеры в таблице)
        /// </summary>
        public ICourierScheduleRowModel Сourier
        {
            get;
            set;
        }
    }
}
