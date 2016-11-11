using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Таблица планировани работы сотрудников по сменам
    /// </summary>
    public interface IShiftPersonalScheduleReportModel
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
        /// График работы отдела (строка отдел в таблице).
        /// </summary>
        List<IDepartamentScheduleRowModel> DepartamentScheduleRows
        {
            get;
            set;
        }

        /// <summary>
        /// Курьеры (строка Курьеры в таблице)
        /// </summary>
        ICourierScheduleRowModel Сourier
        {
            get;
            set;
        }
    }
}
