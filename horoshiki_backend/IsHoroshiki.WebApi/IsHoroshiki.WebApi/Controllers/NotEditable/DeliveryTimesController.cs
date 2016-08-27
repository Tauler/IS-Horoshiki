using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Время доставки
    /// </summary>
    [Authorize]
    public class DeliveryTimesController :  BaseNotEditableController<IDeliveryTimeModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Время доставки</param>
        public DeliveryTimesController(IDeliveryTimeService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
