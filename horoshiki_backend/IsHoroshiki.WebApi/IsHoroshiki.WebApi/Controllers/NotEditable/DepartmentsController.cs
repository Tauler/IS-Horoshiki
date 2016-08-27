using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Отделы
    /// </summary>
    [Authorize]
    public class DepartmentsController : BaseNotEditableController<IDepartmentModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус площадки</param>
        public DepartmentsController(IDepartmentService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
