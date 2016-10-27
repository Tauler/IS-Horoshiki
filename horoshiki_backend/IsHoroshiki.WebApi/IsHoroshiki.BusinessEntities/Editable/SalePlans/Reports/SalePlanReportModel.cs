using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports
{
    /// <summary>
    /// Отчет продаж
    /// </summary>
    public class SalePlanReportModel : ISalePlanReportModel
    {
        /// <summary>
        /// План продаж
        /// </summary>
        public ISalePlanModel SalePlan
        {
            get;
            set;
        }

        /// <summary>
        /// Строка отчета
        /// </summary>
        public List<ISalePlanReportRowModel> DataRows
        {
            get;
            set;
        }

        /// <summary>
        /// Итоговая строка отчета
        /// </summary>
        public ISalePlanReportSumRowModel SumRow
        {
            get;
            set;
        }
    }
}
