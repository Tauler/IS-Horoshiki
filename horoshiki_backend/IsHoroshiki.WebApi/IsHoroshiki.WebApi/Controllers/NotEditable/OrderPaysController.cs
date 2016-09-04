using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Оплата заказа
    /// </summary>
    [Authorize]
    public class OrderPaysController : BaseNotEditableController<IOrderPayModel, IOrderPayService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Оплата заказа</param>
        public OrderPaysController(IOrderPayService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
