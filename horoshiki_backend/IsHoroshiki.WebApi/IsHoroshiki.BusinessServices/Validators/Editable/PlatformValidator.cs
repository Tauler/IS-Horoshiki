using System;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
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
                return new ValidationResult(PlatformErrors.NameIsNull);
            }

            if (element.SubDivision == null)
            {
                return new ValidationResult(PlatformErrors.SubDivisionIsNullModel);
            }

            if (element.BuyProcesses == null || element.BuyProcesses.Count == 0)
            {
                return new ValidationResult(PlatformErrors.BuyProcessesIsNullModel);
            }

            if (element.PlatformStatus == null)
            {
                return new ValidationResult(PlatformErrors.PlatformStatusIsNullModel);
            }

            if (element.TimeStart == TimeSpan.MinValue)
            {
                return new ValidationResult(PlatformErrors.TimeStartIsNullModel);
            }

            if (element.TimeEnd == TimeSpan.Zero || element.TimeEnd == TimeSpan.MinValue)
            {
                return new ValidationResult(PlatformErrors.TimeEndIsNullModel);
            }

            if (element.MinCheck == 0)
            {
                return new ValidationResult(PlatformErrors.MinChecksIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
