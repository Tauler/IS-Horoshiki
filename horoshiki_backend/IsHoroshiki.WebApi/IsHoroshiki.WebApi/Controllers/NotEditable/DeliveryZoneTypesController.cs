using System.Web.Http;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Типы зон доставки
    /// </summary>
    [Authorize]
    public class DeliveryZoneTypesController : BaseNotEditableController<IDeliveryZoneTypeModel, IDeliveryZoneTypeService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Типы зон доставки</param>
        public DeliveryZoneTypesController(IDeliveryZoneTypeService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
