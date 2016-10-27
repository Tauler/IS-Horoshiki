using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Строка отчета
    /// </summary>
    public interface ISalePlanReportRowModel
    {
        /// <summary>
        /// Дата начала периода
        /// </summary>
        DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        DateTime DateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Текстовое описание периода
        /// </summary>
        string PeriodDescription
        {
            get;
        }

        /// <summary>
        /// Сумма суши за период
        /// </summary>
        decimal Sushi
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма пицца за период
        /// </summary>
        decimal Pizza
        {
            get;
            set;
        }

        /// <summary>
        /// Итого
        /// </summary>
        decimal Sum
        {
            get;
        }
    }
}