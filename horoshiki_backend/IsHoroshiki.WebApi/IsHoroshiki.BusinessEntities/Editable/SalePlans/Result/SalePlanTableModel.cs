using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Сформированый план продаж
    /// </summary>
    public class SalePlanTableModel : ISalePlanTableModel
    {
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
