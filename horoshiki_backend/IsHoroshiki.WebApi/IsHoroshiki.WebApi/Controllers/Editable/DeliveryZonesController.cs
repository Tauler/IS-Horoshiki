using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Зона доставки
    /// </summary>
    [Authorize]
    [RoutePrefix("api/DeliveryZones")]
    public class DeliveryZonesController : BaseEditableController<IDeliveryZoneModel, IDeliveryZoneService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус сотрудника</param>
        public DeliveryZonesController(IDeliveryZoneService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
