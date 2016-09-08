using IsHoroshiki.BusinessServices.Kladr;
using IsHoroshiki.WebApi.Handlers;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace IsHoroshiki.WebApi.Controllers.Kladr
{
    /// <summary>
    /// Контроллер КЛАДР
    /// </summary>
    [Authorize]
    public class KladrController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly IKladrService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        public KladrController(IKladrService service)
        {
            _service = service;
        }

        #endregion

        #region методы

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="contentType">Тип искомого объекта (область, район и т.п.)</param>
        /// <param name="query">Наименование объекта в запросе</param>
        /// <param name="regionId">Id объекта в запросе</param>
        /// <param name="withParent">true - если необходимо вернуть родительскте записи для данного объекта</param>
        /// <param name="limit">Максимальное количество записей в ответе</param>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string contentType, string query = "", string regionId = "", bool withParent = false, int limit = 10)
        {
            try
            {
                var list = await _service.Get(contentType, query, regionId, withParent, limit);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        #endregion

        #region IDisposable 

        /// <summary>  
        /// IDisposable
        /// </summary>  
        /// <param name="disposing"></param>  
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!this._disposed && disposing)
            {
                _service.Dispose();
            }
            this._disposed = true;
        }

        #endregion
    }
}
