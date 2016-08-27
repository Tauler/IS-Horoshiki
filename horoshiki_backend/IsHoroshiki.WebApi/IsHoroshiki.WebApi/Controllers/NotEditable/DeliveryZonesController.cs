using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Типы зон доставки
    /// </summary>
    [Authorize]
    public class DeliveryZonesController : BaseNotEditableController<IDeliveryZoneModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Типы зон доставки</param>
        public DeliveryZonesController(IDeliveryZoneService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
