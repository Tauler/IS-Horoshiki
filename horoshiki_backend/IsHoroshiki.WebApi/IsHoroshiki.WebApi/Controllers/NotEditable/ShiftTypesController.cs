using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditable
{
    /// <summary>
    /// Контроллер Тип смены
    /// </summary>
    [Authorize]
    public class ShiftTypesController : BaseNotEditableController<IShiftTypeModel, IShiftTypeService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Тип смены</param>
        public ShiftTypesController(IShiftTypeService service)
            : base(service)
        {

        }

        #endregion
    }
}
