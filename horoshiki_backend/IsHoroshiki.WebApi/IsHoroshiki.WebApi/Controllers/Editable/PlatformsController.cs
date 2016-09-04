using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Платформа
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Platforms")]
    public class PlatformsController : BaseEditableController<IPlatformModel, IPlatformService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Платформа</param>
        public PlatformsController(IPlatformService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
