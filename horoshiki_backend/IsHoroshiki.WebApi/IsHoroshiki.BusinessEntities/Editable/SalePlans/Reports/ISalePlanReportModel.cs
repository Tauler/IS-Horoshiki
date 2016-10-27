using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Отчет продаж
    /// </summary>
    public interface ISalePlanReportModel
    {
        /// <summary>
        /// План продаж
        /// </summary>
        ISalePlanModel SalePlan
        {
            get;
            set;
        }

        /// <summary>
        /// Строка отчета
        /// </summary>
        List<ISalePlanReportRowModel> DataRows
        {
            get;
            set;
        }

        /// <summary>
        /// Итоговая строка отчета
        /// </summary>
        ISalePlanReportSumRowModel SumRow
        {
            get;
            set;
        }
    }
}
