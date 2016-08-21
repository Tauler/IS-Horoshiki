using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Статус площадки
    /// </summary>
    [Authorize]
    public class PriceTypesController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Типы цен
        /// </summary>
        private readonly IPriceTypeService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус площадки</param>
        public PriceTypesController(IPriceTypeService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Типы цен 
        /// </summary>
        /// <returns></returns>
        // GET api/PriceTypes
        [ResponseType(typeof(IEnumerable<PriceTypeModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
