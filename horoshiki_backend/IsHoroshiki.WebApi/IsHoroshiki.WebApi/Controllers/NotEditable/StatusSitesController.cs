using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Статус площадки
    /// </summary>
    [Authorize]
    public class StatusSitesController : BaseNotEditableController<IPlatformStatusModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус площадки</param>
        public StatusSitesController(IPlatformStatusService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
