using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable;
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
        public async Task<ValidationResult> ValidateAsync(SubDivisionModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(ResourceBusinessServices.Validator_NameIsNull);
            }

            if (element.Timezone == 0)
            {
                return new ValidationResult(ResourceBusinessServices.SubDivisionValidator_TimezoneIsNull);
            }

            if (element.PriceTypeModel == null)
            {
                return new ValidationResult(ResourceBusinessServices.SubDivisionValidator_PriceTypeMIsNullodel);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
