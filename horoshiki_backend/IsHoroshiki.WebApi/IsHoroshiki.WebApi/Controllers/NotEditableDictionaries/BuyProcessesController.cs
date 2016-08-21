using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Способы покупки
    /// </summary>
    [Authorize]
    public class BuyProcessesController : ApiController
    {
        /// <summary>
        /// Получить все Способы покупки 
        /// </summary>
        /// <returns></returns>
        // GET api/BuyProcesses
        [ResponseType(typeof(IEnumerable<BuyProcessModel>))]
        public IHttpActionResult Get()
        {
            using (var buyProcessService = new BuyProcessService())
            {
                return Ok(buyProcessService.GetAll());
            }
        }
    }
}
