using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using System.Web.Http;
using System.Web.Http.Description;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Контроллер-хелпер работы с сервером
    /// </summary>
    [Authorize]
    public class UtilsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис проверки доступности сервера и т.п.
        /// </summary>
        private readonly IUtilService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис проверки доступности сервера и т.п.</param>
        public UtilsController(IUtilService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Проверить доступность сервиса и БД
        /// </summary>
        [ResponseType(typeof(bool))]
        [Route("api/Utils/IsAvailableServer")]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return Ok(_service.IsAvailableServer());
        }

        #endregion
    }
}
