using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор Планированиe графика работы сотрудников на период
    /// </summary>
    public class ShiftPersonalScheduleValidator : IShiftPersonalScheduleValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IShiftPersonalScheduleModel element)
        {
            if (element.ShiftType == null)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.ShiftTypeIsNull);
            }

            if (element.User == null)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.UserIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
