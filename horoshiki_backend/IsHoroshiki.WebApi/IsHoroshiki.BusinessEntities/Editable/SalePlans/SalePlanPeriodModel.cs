using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans
{
    /// <summary>
    /// Период плана продаж
    /// </summary>
    public class SalePlanPeriodModel : ISalePlanPeriodModel
    {
        /// <summary>
        /// Год
        /// </summary>
        public int Year
        {
            get;
            set;
        }

        /// <summary>
        /// Месяц
        /// </summary>
        public int Month
        {
            get;
            set;
        }
    }
}
