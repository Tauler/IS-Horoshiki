using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Статус сотрудника
    /// </summary>
    [Authorize]
    public class EmployeeStatusesController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Статус площадки
        /// </summary>
        private readonly IEmployeeStatusService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус сотрудника</param>
        public EmployeeStatusesController(IEmployeeStatusService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Статус сотрудника 
        /// </summary>
        /// <returns></returns>
        // GET api/EmployeeStatuses
        [ResponseType(typeof(IEnumerable<EmployeeStatusModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
