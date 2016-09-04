using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Способы покупки
    /// </summary>
    [Authorize]
    public class BuyProcessesController : BaseNotEditableController<IBuyProcessModel, IBuyProcessService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Способы покупки</param>
        public BuyProcessesController(IBuyProcessService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
