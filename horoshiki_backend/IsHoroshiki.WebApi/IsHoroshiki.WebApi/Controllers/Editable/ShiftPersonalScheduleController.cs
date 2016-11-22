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
    /// Контроллер График смен для сотрудников
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
        /// Планирование смен сотрудника на определенный день.
        /// Удаляем ВСЕ что нет в списке
        /// </summary>
        [Route("updateCell")]
        public async Task<IHttpActionResult> UpdateCell(IShiftPersonalScheduleUpdateModel model)
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

        /// <summary>
        /// Получение норма часов за период для пользователя
        /// </summary>
        [Route("normaHour")]
        public async Task<IHttpActionResult> NormaHour(IShiftPersonalScheduleNormaHourModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.NormaHour(model);
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
