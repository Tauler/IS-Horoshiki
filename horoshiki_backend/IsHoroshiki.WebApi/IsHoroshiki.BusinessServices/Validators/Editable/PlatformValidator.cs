using System;
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

            if (element.SubDivisionModel == null)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_SubDivisionIsNullModel);
            }

            if (element.BuyProcessesModel == null || element.BuyProcessesModel.Count == 0)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_BuyProcessesIsNullModel);
            }

            if (element.PlatformStatusModel == null)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_PlatformStatusIsNullModel);
            }

            if (element.TimeStart == TimeSpan.Zero || element.TimeStart == TimeSpan.MinValue)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_TimeStartIsNullModel);
            }

            if (element.TimeEnd == TimeSpan.Zero || element.TimeEnd == TimeSpan.MinValue)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_TimeEndIsNullModel);
            }

            if (element.MinCheck == 0)
            {
                return new ValidationResult(ResourceBusinessServices.PlatformValidator_MinChecksIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
