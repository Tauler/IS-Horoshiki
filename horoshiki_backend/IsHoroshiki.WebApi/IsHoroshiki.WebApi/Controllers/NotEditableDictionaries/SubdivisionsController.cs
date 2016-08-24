using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Подразделения
    /// </summary>
    [Authorize]
    public class SubDivisionsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Статус площадки
        /// </summary>
        private readonly ISubDivisionService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Подразделения</param>
        public SubDivisionsController(ISubDivisionService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Подразделения 
        /// </summary>
        /// <returns></returns>
        // GET api/BuyProcesses
        [ResponseType(typeof(IEnumerable<SubDivisionModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
