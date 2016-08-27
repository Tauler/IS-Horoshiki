using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Статус заказа
    /// </summary>
    [Authorize]
    public class OrderStatusesController : BaseNotEditableController<IOrderStatusModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус заказа</param>
        public OrderStatusesController(IOrderStatusService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
