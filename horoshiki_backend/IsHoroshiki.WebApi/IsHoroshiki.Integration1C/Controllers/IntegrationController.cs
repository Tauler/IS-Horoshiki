using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessServices.Helpers;
using IsHoroshiki.BusinessServices.Integrations;
using System;
using System.IO;
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
                try
                {
                    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Logs\\test_kuki.txt");
                  
                    try
                    {
                        File.AppendAllText(path, "gggggggggggggggggggggggg");
                        File.AppendAllText(path, this.Request.Headers.Authorization.Parameter);
                        File.AppendAllText(path, this.Request.Headers.Authorization.Scheme);
                    }
                    catch (Exception e)
                    {
                        File.AppendAllText(path, e.Message);
                    }
                }
                catch (Exception e)
                {
                    
                }

                IIntegrationService service = new IntegrationService();
                return await service.Save(model);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                Logger.Error(e.StackTrace);
                return false;
            }
        }

        #endregion
    }
}
