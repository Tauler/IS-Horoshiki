using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Оплата заказа
    /// </summary>
    [Authorize]
    public class OrderPaysController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Оплата заказа
        /// </summary>
        private readonly IOrderPayService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Оплата заказа</param>
        public OrderPaysController(IOrderPayService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Оплата заказа 
        /// </summary>
        /// <returns></returns>
        // GET api/OrderPays
        [ResponseType(typeof(IEnumerable<OrderPayModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
