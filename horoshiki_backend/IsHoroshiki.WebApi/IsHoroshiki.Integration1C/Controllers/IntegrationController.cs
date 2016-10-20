using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessServices.Integrations;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace IsHoroshiki.Integration1C.Controllers
{
    /// <summary>
    /// Контроллер интеграции с 1С
    /// </summary>
    [RoutePrefix("api/integration")]
    public class IntegrationController : ApiController
    {
        #region методы

        /// <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        [HttpPost]
        [Route("check")]
        public async Task<bool> Save(IntegrationCheckModel model)
        {
            try
            {
                IIntegrationService service = new IntegrationService();
                return await service.Save(model);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
