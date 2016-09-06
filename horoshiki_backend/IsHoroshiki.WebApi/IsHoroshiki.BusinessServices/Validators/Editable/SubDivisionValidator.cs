using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор подразделений
    /// </summary>
    public class SubDivisionValidator : ISubDivisionValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(ISubDivisionModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(SubDivisionErrors.NameIsNull);
            }

            if (element.Timezone == 0)
            {
                return new ValidationResult(SubDivisionErrors.TimezoneIsNull);
            }

            if (element.Timezone > 12 || element.Timezone < -12)
            {
                return new ValidationResult(SubDivisionErrors.TimezoneInvalidPeriod);
            }

            if (element.PriceTypeModel == null)
            {
                return new ValidationResult(SubDivisionErrors.PriceTypeIsNullModel);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
