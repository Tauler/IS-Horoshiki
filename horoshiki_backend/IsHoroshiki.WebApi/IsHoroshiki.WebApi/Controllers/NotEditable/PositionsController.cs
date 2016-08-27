using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Должности
    /// </summary>
    [Authorize]
    public class PositionsController : BaseNotEditableController<IPositionModel>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Должности</param>
        public PositionsController(IPositionService service)
            : base(service)
        {
            
        }

        #endregion
    }
}
