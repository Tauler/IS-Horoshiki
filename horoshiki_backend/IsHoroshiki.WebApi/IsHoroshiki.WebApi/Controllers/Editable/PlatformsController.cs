using System.Web.Http;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System.Threading.Tasks;
using System;
using IsHoroshiki.WebApi.Handlers;
using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessServices;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер Площадка
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Platforms")]
    public class PlatformsController : BaseEditableController<IPlatformModel, IPlatformService>
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Площадка</param>
        public PlatformsController(IPlatformService service)
            : base(service)
        {
            
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все площадки для подразделения
        /// </summary>
        /// <param name="subDivisionId">Id подразделения</param>
        [Route("subDivision")]
        public async Task<IHttpActionResult> GetAllBySubDivision(int subDivisionId)
        {
            try
            {
                var list = await _service.GetAllBySubDivision(subDivisionId);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Сохранение координат площадки
        /// </summary>
        /// <param name="model">Модель сохранения координат площадки</param>
        [HttpPost]
        [Route("addYandexMap")]
        public async Task<IHttpActionResult> AddYandexMapToPlatform(AddYandexMapPlatformModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return GetErrorResult(ModelState);
                }

                ModelEntityModifyResult result = await _service.AddYandexMapToPlatform(model.PlatformId, model.YandexMap);
                if (!result.IsValidationSucceeded || !result.IsSucceeded)
                {
                    return new ErrorMessageResult(result.ValidationErrors);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        #endregion
    }
}
