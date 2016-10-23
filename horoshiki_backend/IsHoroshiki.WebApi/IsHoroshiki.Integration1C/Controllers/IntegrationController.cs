using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessServices.Helpers;
using IsHoroshiki.BusinessServices.Integrations;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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

                var value = GetCookie(Request, "authentication");
                if (!string.IsNullOrEmpty(value) && value.ToUpper() == "one_c_robot:a582cacfdd4061ae060838ddc357d483".ToUpper())
                {
                    IIntegrationService service = new IntegrationService();
                    return await service.Save(model);
                }
                else
                {
                    Logger.Error("Не авторизации в заголовке!!!");
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                Logger.Error(e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Retrieves an individual cookie from the cookies collection
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        private string GetCookie(HttpRequestMessage request, string cookieName)
        {
            CookieHeaderValue cookie = request.Headers.GetCookies(cookieName).FirstOrDefault();
            if (cookie != null)
            {
                return cookie[cookieName].Value;
            }

            return null;
        }

        #endregion
    }
}
