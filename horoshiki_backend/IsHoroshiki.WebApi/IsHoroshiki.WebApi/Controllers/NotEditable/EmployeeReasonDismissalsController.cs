using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Причины увольнения сотрудника
    /// </summary>
    [Authorize]
    public class EmployeeReasonDismissalsController : BaseNotEditableController<IEmployeeReasonDismissalModel, IEmployeeReasonDismissalService>
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
