using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер ПодОтделы
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
    }
}
