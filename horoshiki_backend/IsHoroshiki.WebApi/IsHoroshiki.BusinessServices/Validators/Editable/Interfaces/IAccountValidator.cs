using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Account.Interfaces;

namespace IsHoroshiki.BusinessServices.Validators.Editable.Interfaces
{
    /// <summary>
    /// Валидатор Пользователь
    /// </summary>
    public interface IAccountValidator : IValidator<IApplicationUserModel>
    {
        /// <summary>
        /// Валидация без пароля
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        Task<ValidationResult> ValidateWithoutPasswordAsync(IApplicationUserModel element);
    }
}
