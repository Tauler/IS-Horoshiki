using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для плана продаж
    /// </summary>
    public enum SalePlanErrors
    {
        /// <summary>
        /// Необходимо указать площадку
        /// </summary>
        PlatformIsNull,

        /// <summary>
        /// Необходимо указать период плана продаж
        /// </summary>
        SalePlanPeriodIsNull,

        /// <summary>
        /// Необходимо указать месяц период плана
        /// </summary>
        SalePlanPeriodMonthIsNull,

        /// <summary>
        /// Необходимо указать год плана продаж
        /// </summary>
        SalePlanPeriodYearIsNull,

        /// <summary>
        /// Необходимо указать период Анализ1 плана продаж
        /// </summary>
        AnalizePeriod1IsNull,

        /// <summary>
        /// Необходимо указать месяц Анализ1 плана продаж
        /// </summary>
        AnalizePeriod1MonthIsNull,

        /// <summary>
        /// Необходимо указать год Анализ1 плана продаж
        /// </summary>
        AnalizePeriod1YearIsNull,

        /// <summary>
        /// Необходимо указать период Анализ2 плана продаж
        /// </summary>
        AnalizePeriod2IsNull,

        /// <summary>
        /// Необходимо указать месяц Анализ2 плана продаж
        /// </summary>
        AnalizePeriod2MonthIsNull,

        /// <summary>
        /// Необходимо указать год Анализ2 плана продаж
        /// </summary>
        AnalizePeriod2YearIsNull,

        /// <summary>
        /// Не указан средний чек!
        /// </summary>
        AverageCheckIsNull,

        /// <summary>
        /// Плана продаж на указанную дату не существует!
        /// </summary>
        SalePlanNotExit
    }
}
