using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор  План продаж
    /// </summary>
    public class SalePlanValidator : ISalePlanValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(ISalePlanModel element)
        {
            if (element.Platform == null )
            {
                return new ValidationResult(SalePlanErrors.PlatformIsNull);
            }


            if (element.SalePlanPeriod == null)
            {
                return new ValidationResult(SalePlanErrors.SalePlanPeriodIsNull);
            }

            if (element.SalePlanPeriod.Month == 0)
            {
                return new ValidationResult(SalePlanErrors.SalePlanPeriodMonthIsNull);
            }

            if (element.SalePlanPeriod.Year == 0)
            {
                return new ValidationResult(SalePlanErrors.SalePlanPeriodYearIsNull);
            }


            if (element.AnalizePeriod1 == null)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod1IsNull);
            }

            if (element.AnalizePeriod1.Month == 0)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod1MonthIsNull);
            }

            if (element.AnalizePeriod1.Year == 0)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod1YearIsNull);
            }


            if (element.AnalizePeriod2 == null)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod2IsNull);
            }

            if (element.AnalizePeriod2.Month == 0)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod2MonthIsNull);
            }

            if (element.AnalizePeriod2.Year == 0)
            {
                return new ValidationResult(SalePlanErrors.AnalizePeriod2YearIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
