using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Вадидатор смены
    /// </summary>
    public class ShiftPersonalValidator : IShiftPersonalValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IShiftPersonalModel element)
        {
            return new ValidationResult();
        }

        #endregion
    }
}
