using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessServices.Errors.Enums;

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
            if (element.Position == null)
            {
                return new ValidationResult(ShiftPersonalErrors.PositionIsNull);
            }
            if (element.ShiftType == null)
            {
                return new ValidationResult(ShiftPersonalErrors.ShiftTypeIsNull);
            }
            return new ValidationResult();
        }

        #endregion
    }
}
