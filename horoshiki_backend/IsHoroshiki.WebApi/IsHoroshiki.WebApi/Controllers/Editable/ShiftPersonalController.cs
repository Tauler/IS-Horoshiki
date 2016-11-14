using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Смена
    /// </summary>
    public class ShiftPersonalController : BaseController<IShiftPersonalModel>
    {
        #region Поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly IShiftPersonalService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис Смена</param>
        public ShiftPersonalController(IShiftPersonalService service)
            : base(service)
        {
            _service = service;
        }

        #endregion
    }
}
