using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор Пользователей
    /// </summary>
    public class AccountValidator : IAccountValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IApplicationUserModel element)
        {
            return await ValidateAsync(element , true);
        }

        /// <summary>
        /// Валидация без пароля
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateWithoutPasswordAsync(IApplicationUserModel element)
        {
            return await ValidateAsync(element, false);
        }

        #endregion

        #region private

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <param name="isCheckPassword">true - проверить пароль</param>
        /// <returns></returns>
        private async Task<ValidationResult> ValidateAsync(IApplicationUserModel element, bool isCheckPassword)
        {
            if (string.IsNullOrEmpty(element.FirstName))
            {
                return new ValidationResult(AccountErrors.FirstNameIsNull);
            }

            if (string.IsNullOrEmpty(element.LastName))
            {
                return new ValidationResult(AccountErrors.LastNameIsNull);
            }

            if (string.IsNullOrEmpty(element.UserName))
            {
                return new ValidationResult(AccountErrors.UserNameIsNull);
            }

            if (element.IsHaveMedicalBook && element.MedicalBookEnd == null)
            {
                return new ValidationResult(AccountErrors.IsHaveMedicalBookMedicalBookEnd);
            }

            if (isCheckPassword)
            {
                if (string.IsNullOrEmpty(element.Password))
                {
                    return new ValidationResult(AccountErrors.PasswordIsNull);
                }

                if (string.IsNullOrEmpty(element.ConfirmPassword))
                {
                    return new ValidationResult(AccountErrors.ConfirmPasswordIsNull);
                }

                if (!string.Equals(element.Password, element.ConfirmPassword))
                {
                    return new ValidationResult(AccountErrors.PasswordNotEquals);
                }
            }

            if (element.Position == null)
            {
                return new ValidationResult(AccountErrors.PositionIsNull);
            }

            if (element.EmployeeStatus == null)
            {
                return new ValidationResult(AccountErrors.EmployeeStatusIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
