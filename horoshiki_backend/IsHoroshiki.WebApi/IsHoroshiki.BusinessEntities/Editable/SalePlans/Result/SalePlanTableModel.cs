using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Сформированый план продаж
    /// </summary>
    public class SalePlanTableModel : ISalePlanTableModel
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
        public List<ISalePlanDataRowModel> DataRows
        {
            get;
            set;
        }

        /// <summary>
        /// Итоговая строка отчета
        /// </summary>
        public ISalePlanSumRowModel SumRow
        {
            get;
            set;
        }
    }    
}
