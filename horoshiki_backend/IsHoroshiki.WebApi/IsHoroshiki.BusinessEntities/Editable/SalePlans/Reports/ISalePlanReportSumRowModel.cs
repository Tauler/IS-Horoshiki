namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Итоговая строка отчета
    /// </summary>
    public interface ISalePlanReportSumRowModel
    {
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