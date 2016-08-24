using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер ПодОтделы
    /// </summary>
    [Authorize]
    public class SubDepartmentsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис ПодОтделы
        /// </summary>
        private readonly ISubDepartmentService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис ПодОтделы</param>
        public SubDepartmentsController(ISubDepartmentService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Отделы 
        /// </summary>
        /// <returns></returns>
        // GET api/Departments
        [ResponseType(typeof(IEnumerable<SubDepartmentModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
