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
    public class SalePlanController : BaseEditableController<ISalePlanModel, ISalePlanService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис План продаж</param>
        public SalePlanController(ISalePlanService service)
            : base(service)
        {
            
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Создать план
        /// </summary>
        [Route("create")]
        public async Task<IHttpActionResult> CreatePlan(ISalePlanModel model)
        {
            try
            {
                var list = await _service.CreatePlan(model);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        #endregion
    }
}
