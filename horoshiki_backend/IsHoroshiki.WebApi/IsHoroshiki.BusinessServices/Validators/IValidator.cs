using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities;

namespace IsHoroshiki.BusinessServices.Validators
{
    /// <summary>
    /// Валидатор
    /// </summary>
    /// <typeparam name="T">Тип валидации</typeparam>
    public interface IValidator<T>
        where T : IBaseBusninessModel
    {
        /// <summary>
        /// Валидатор
        /// </summary>
        /// <param name="element">Тип валидации</param>
        /// <returns></returns>
        Task<ValidationResult> ValidateAsync(T element);
    }
}
