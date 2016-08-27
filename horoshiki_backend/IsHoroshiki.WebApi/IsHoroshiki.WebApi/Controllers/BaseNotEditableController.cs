using System;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices;
using IsHoroshiki.BusinessServices.Helpers;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Абстрактный класс нередактируемого контроллера
    /// </summary>
    public class BaseNotEditableController<TModelEnty> : BaseController<TModelEnty>
        where TModelEnty : class, IBaseNotEditableModel
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        protected readonly IBaseNotEditableService<TModelEnty> _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        protected BaseNotEditableController(IBaseNotEditableService<TModelEnty> service)
        {
            _service = service;
        }

        #endregion

        /// <summary>
        /// Получить все записи
        /// </summary>
        //[ResponseType(typeof(IEnumerable<TModelEnty>))]
        public virtual async Task<IHttpActionResult> Get()
        {
            try
            {
                var list = await _service.GetAllAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetAllMessages());
            }
        }

    }
}
