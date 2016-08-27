using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessServices.Editable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Подразделения
    /// </summary>
    [Authorize]
    public class SubDivisionsController : BaseEditableController<SubDivisionModel>
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
