using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.WebApi.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Смена
    /// </summary>
    [Authorize]
    [RoutePrefix("api/shiftPersonals")]
    public class ShiftPersonalsController : BaseController<IShiftPersonalModel>
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
        public ShiftPersonalsController(IShiftPersonalService service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        #region Методы контроллера

        /// <summary>
        /// Редактировать смену
        /// </summary>
        [Route("Table")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTable()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.GetTable();
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать смену
        /// </summary>
        [Route("Update")]
        public async Task<IHttpActionResult> UpdateWorkingTime(IShiftPersonalModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.UpdateWorkingTime(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }


        #endregion
    }
}
