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
            return new ValidationResult();
        }

        #endregion
    }
}
