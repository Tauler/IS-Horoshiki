using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Причины увольнения сотрудника
    /// </summary>
    [Authorize]
    [RoutePrefix("api/EmployeeReasonDismissals")]
    public class EmployeeReasonDismissalsController : BaseEditableController<IEmployeeReasonDismissalModel, IEmployeeReasonDismissalService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус сотрудника</param>
        public EmployeeReasonDismissalsController(IEmployeeReasonDismissalService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
