using System;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор Площадка
    /// </summary>
    public class PlatformValidator : IPlatformValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IPlatformModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(PlatformErrors.NameIsNull);
            }

            if (element.SubDivision == null)
            {
                return new ValidationResult(PlatformErrors.SubDivisionIsNullModel);
            }

            if (element.BuyProcesses == null || element.BuyProcesses.Count == 0)
            {
                return new ValidationResult(PlatformErrors.BuyProcessesIsNullModel);
            }

            if (element.PlatformStatus == null)
            {
                return new ValidationResult(PlatformErrors.PlatformStatusIsNullModel);
            }

            if (element.TimeStart == TimeSpan.MinValue)
            {
                return new ValidationResult(PlatformErrors.TimeStartIsNullModel);
            }

            if (element.TimeEnd == TimeSpan.Zero || element.TimeEnd == TimeSpan.MinValue)
            {
                return new ValidationResult(PlatformErrors.TimeEndIsNullModel);
            }

            if (element.MinCheck == 0)
            {
                return new ValidationResult(PlatformErrors.MinChecksIsNull);
            }

            if (element.IsAroundClock)
            {
                var timeStartTicks = new TimeSpan(0, 0, 0).Ticks;
                var timeEndTicks = new TimeSpan(1, 0, 0, 0).Ticks;

                if (element.TimeStart.Ticks != timeStartTicks)
                {
                    return new ValidationResult(PlatformErrors.WrongTimeStartForAroundClock);
                }

                if (element.TimeEnd.Ticks != timeEndTicks)
                {
                    return new ValidationResult(PlatformErrors.WrongTimeEndForAroundClock);
                }

                if (element.OrderTimeStart.Ticks != timeStartTicks)
                {
                    return new ValidationResult(PlatformErrors.WrongOrderTimeStartForAroundClock);
                }

                if (element.OrderTimeEnd.Ticks != timeEndTicks)
                {
                    return new ValidationResult(PlatformErrors.WrongOrderTimeEndForAroundClock);
                }
            }

            return new ValidationResult();
        }

        #endregion
    }
}
