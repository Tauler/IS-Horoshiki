using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Должности
    /// </summary>
    [Authorize]
    public class PositionsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Должности
        /// </summary>
        private readonly IPositionService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Должности</param>
        public PositionsController(IPositionService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Статус площадки 
        /// </summary>
        /// <returns></returns>
        // GET api/Positions
        [ResponseType(typeof(IEnumerable<PositionModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
