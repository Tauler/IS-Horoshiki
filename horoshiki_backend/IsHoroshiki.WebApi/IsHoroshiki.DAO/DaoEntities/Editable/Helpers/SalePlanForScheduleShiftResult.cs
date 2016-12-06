using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.DaoEntities.Editable.Helpers
{
    /// <summary>
    /// Результат выполнения табличной функции GetSalePlanForScheduleShift
    /// </summary>
    public class SalePlanForScheduleShiftResult
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во
        /// </summary>
        public int Count
        {
            get;
            set;
        }
    }
}
