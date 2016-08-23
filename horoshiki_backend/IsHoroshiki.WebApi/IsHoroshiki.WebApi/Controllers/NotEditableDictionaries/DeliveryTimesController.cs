using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Время доставки
    /// </summary>
    [Authorize]
    public class DeliveryTimesController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Типы зон доставки
        /// </summary>
        private readonly IDeliveryTimeService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Время доставки</param>
        public DeliveryTimesController(IDeliveryTimeService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Время доставки
        /// </summary>
        /// <returns></returns>
        // GET api/DeliveryTimes
        [ResponseType(typeof(IEnumerable<DeliveryTimeModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
