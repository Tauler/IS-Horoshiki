using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System.Threading.Tasks;
using System;
using IsHoroshiki.WebApi.Handlers;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер План продаж
    /// </summary>
    [Authorize]
    [RoutePrefix("api/salePlan")]
    public class SalePlanController : BaseController<ISalePlanModel>
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly ISalePlanService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис План продаж</param>
        public SalePlanController(ISalePlanService service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        [Route("{id}")]
        public override async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.Add(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Создать план
        /// </summary>
        [Route("add")]
        public async Task<IHttpActionResult> Add(ISalePlanModel model)
        {
            try
            {
                var result = await _service.Add(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать план
        /// </summary>
        [Route("Update")]
        public async Task<IHttpActionResult> Update(ISalePlanModel model)
        {
            try
            {
                var result = await _service.Update(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать cредний чек плана 
        /// </summary>
        [Route("UpdateAverageCheck")]
        public async Task<IHttpActionResult> UpdateAverageCheck(ISalePlanModel model)
        {
            try
            {
                var result = await _service.UpdateAverageCheck(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        [Route("UpdateCell")]
        public async Task<IHttpActionResult> UpdateCell(ISalePlanCellModel model)
        {
            try
            {
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
