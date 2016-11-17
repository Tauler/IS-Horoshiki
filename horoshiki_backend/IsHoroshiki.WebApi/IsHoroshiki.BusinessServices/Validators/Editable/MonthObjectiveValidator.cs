using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор Цель на месяц по показателям
    /// </summary>
    public class MonthObjectiveValidator : IMonthObjectiveValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IMonthObjectiveModel element)
        {
            if (element.Platform == null)
            {
                return new ValidationResult(MonthObjectiveErrors.PlatformIsNull);
            }
            if (element.Year == 0)
            {
                return new ValidationResult(MonthObjectiveErrors.YearIsNull);
            }
            if (element.Month == 0)
            {
                return new ValidationResult(MonthObjectiveErrors.MonthIsNull);
            }
            return new ValidationResult();
        }

        #endregion
    }
}
