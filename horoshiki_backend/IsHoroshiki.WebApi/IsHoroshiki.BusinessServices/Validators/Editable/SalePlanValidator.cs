using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор  План продаж
    /// </summary>
    public class SalePlanValidator : ISalePlanValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(ISalePlanModel element)
        {
            return new ValidationResult();
        }

        #endregion
    }
}
