using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using IsHoroshiki.WebApi.Handlers;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Цель на месяц по показателям
    /// </summary>
    [Authorize]
    [RoutePrefix("api/MonthObjectives")]
    public class MonthObjectivesController : BaseController<IMonthObjectiveModel>
    {
        #region Поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly IMonthObjectiveService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис Смена</param>
        public MonthObjectivesController(IMonthObjectiveService service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        #region Методы контроллера

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        public override async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.Add(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Создать цель на месяц по показателям
        /// </summary>
        [Route("Add")]
        public async Task<IHttpActionResult> Add(IMonthObjectiveModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.Add(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать цель на месяц по показателям
        /// </summary>
        [Route("Update")]
        public async Task<IHttpActionResult> Update(IMonthObjectiveModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                var result = await _service.UpdateChecksPerHourForPosition(model);
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
