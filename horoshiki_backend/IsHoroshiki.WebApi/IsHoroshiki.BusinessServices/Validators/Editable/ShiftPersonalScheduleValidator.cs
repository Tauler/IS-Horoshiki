using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
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
            
            return new ValidationResult();
        }

        #endregion
    }
}
