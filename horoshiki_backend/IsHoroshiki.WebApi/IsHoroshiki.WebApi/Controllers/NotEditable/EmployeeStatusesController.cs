using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Статус сотрудника
    /// </summary>
    [Authorize]
    public class EmployeeStatusesController : BaseNotEditableController<IEmployeeStatusModel, IEmployeeStatusService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус сотрудника</param>
        public EmployeeStatusesController(IEmployeeStatusService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
