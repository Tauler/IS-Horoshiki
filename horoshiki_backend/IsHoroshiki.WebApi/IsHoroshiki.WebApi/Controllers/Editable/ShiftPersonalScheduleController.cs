using System.Web.Http;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System.Threading.Tasks;
using System;
using IsHoroshiki.WebApi.Handlers;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using System.Collections.Generic;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер План продаж
    /// </summary>
    [Authorize]
    [RoutePrefix("api/shiftPersonalSchedule")]
    public class ShiftPersonalScheduleController : BaseController<IShiftPersonalScheduleModel>
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly IShiftPersonalScheduleService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис План продаж</param>
        public ShiftPersonalScheduleController(IShiftPersonalScheduleService service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// График смен сотрудников
        /// </summary>
        [Route("table")]
        public async Task<IHttpActionResult> Table(IShiftPersonalScheduleDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.GetTable(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать список смен сотрудника
        /// </summary>
        [Route("updateCell")]
        public async Task<IHttpActionResult> UpdateCell(ICollection<IShiftPersonalScheduleModel> model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.UpdateCell(model);
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
