using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Отделы
    /// </summary>
    [Authorize]
    public class DepartmentsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Статус площадки
        /// </summary>
        private readonly IDepartmentService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус площадки</param>
        public DepartmentsController(IDepartmentService service)
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
        [ResponseType(typeof(IEnumerable<DepartmentModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
