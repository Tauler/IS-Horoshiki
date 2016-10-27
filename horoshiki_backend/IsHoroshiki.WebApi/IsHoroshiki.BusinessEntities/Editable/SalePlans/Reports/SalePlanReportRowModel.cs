using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Строка отчета
    /// </summary>
    public class SalePlanReportRowModel : ISalePlanReportRowModel
    {
        /// <summary>
        /// Дата начала периода
        /// </summary>
        public DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        public DateTime DateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Текстовое описание периода
        /// </summary>
        public string PeriodDescription
        {
            get
            {
                return string.Format("{0} - {1}", DateStart.ToString("dd.MM"), DateEnd.ToString("dd.MM"));
            }
        }

        /// <summary>
        /// Сумма суши за период
        /// </summary>
        public decimal Sushi
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма пицца за период
        /// </summary>
        public decimal Pizza
        {
            get;
            set;
        }

        /// <summary>
        /// Итого
        /// </summary>
        public decimal Sum
        {
            get
            {
                return Sushi + Pizza;
            }
        }
    }
}