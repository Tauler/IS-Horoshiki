using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Подразделения
    /// </summary>
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/SubDivisions")]
    public class SubDivisionsController : BaseEditableController<ISubDivisionModel, ISubDivisionService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Подразделения</param>
        public SubDivisionsController(ISubDivisionService service)
            : base(service)
        {

        }

        #endregion
    }
}

