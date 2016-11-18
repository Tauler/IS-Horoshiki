using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для Цель на месяц по показателям
    /// </summary>
    public enum MonthObjectiveErrors
    {
        /// <summary>
        /// Необходимо указать площадку для цели
        /// </summary>
        PlatformIsNull,

        /// <summary>
        /// Необходимо указать год для цели
        /// </summary>
        YearIsNull,

        /// <summary>
        /// Необходимо указать месяц для цели
        /// </summary>
        MonthIsNull,
    }
}
