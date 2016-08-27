using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор Платформа
    /// </summary>
    public class PlatformValidator : IPlatformValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IPlatformModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(ResourceBusinessServices.Validator_NameIsNull);
            }

            //if (element.PriceTypeModel == null)
            //{
            //    return new ValidationResult(ResourceBusinessServices.SubDivisionValidator_PriceTypeIsNullModel);
            //}

            return new ValidationResult();
        }

        #endregion
    }
}
