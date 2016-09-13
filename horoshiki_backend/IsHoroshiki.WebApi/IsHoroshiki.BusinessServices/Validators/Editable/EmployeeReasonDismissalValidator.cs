using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор причин увольнения
    /// </summary>
    public class EmployeeReasonDismissalValidator : IEmployeeReasonDismissalValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IEmployeeReasonDismissalModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(EmployeeReasonDismissalErrors.NameIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
