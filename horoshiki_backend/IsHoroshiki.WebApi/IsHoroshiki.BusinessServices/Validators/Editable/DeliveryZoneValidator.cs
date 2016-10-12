using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Validators.Editable
{
    /// <summary>
    /// Валидатор зон доставки
    /// </summary>
    public class DeliveryZoneValidator : IDeliveryZoneValidator
    {
        #region IValidator

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateAsync(IDeliveryZoneModel element)
        {
            if (string.IsNullOrEmpty(element.Name))
            {
                return new ValidationResult(DeliveryZoneErrors.NameIsNull);
            }

            if (element.DeliveryZoneType == null)
            {
                return new ValidationResult(DeliveryZoneErrors.DeliveryZoneTypeIsNull);
            }

            if (string.IsNullOrEmpty(element.Сoordinates))
            {
                return new ValidationResult(DeliveryZoneErrors.СoordinatesIsNull);
            }

            return new ValidationResult();
        }

        #endregion
    }
}
