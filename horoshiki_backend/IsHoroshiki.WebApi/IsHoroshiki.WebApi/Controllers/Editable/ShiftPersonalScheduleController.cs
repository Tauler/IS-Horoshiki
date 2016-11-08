using System.Web.Http;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System.Threading.Tasks;
using System;
using IsHoroshiki.WebApi.Handlers;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;

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
        /// Отчет плана продаж
        /// </summary>
        [Route("report")]
        public async Task<IHttpActionResult> Report(IShiftPersonalScheduleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.GetReport(model);
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
