namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Итоговая строка отчета
    /// </summary>
    public class SalePlanReportSumRowModel : ISalePlanReportSumRowModel
    {
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