using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Типы зон доставки
    /// </summary>
    [Authorize]
    public class DeliveryZoneTypesController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Типы зон доставки
        /// </summary>
        private readonly IDeliveryZoneTypeService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Типы зон доставки</param>
        public DeliveryZoneTypesController(IDeliveryZoneTypeService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Типы зон доставки 
        /// </summary>
        /// <returns></returns>
        // GET api/DeliveryZoneTypes
        [ResponseType(typeof(IEnumerable<DeliveryZoneTypeModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
