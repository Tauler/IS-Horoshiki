using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using System.Threading.Tasks;
using System;
using IsHoroshiki.WebApi.Handlers;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Подoтделы
    /// </summary>
    [Authorize]
    public class SubDepartmentsController : BaseNotEditableController<ISubDepartmentModel, ISubDepartmentService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис ПодОтделы</param>
        public SubDepartmentsController(ISubDepartmentService service)
            : base(service)
        {
           
        }

        #endregion

        #region методы

        /// <summary>
        /// Найти все подотделя для отдела
        /// </summary>
        /// <param name="departamentId">Id отдела</param>
        [Route("api/SubDepartments/departament/{departamentId}")]
        public async Task<IHttpActionResult> GetAllByDepartament(int departamentId)
        {
            try
            {
                var result = await _service.GetAllByDepartament(departamentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        #endregion
    }
}
