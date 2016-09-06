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
    public class BaseNotEditableController<TModelEntity, TModelEntityService> : BaseController<TModelEntity>
        where TModelEntity : class, IBaseNotEditableModel
        where TModelEntityService : IBaseNotEditableService<TModelEntity>
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        protected readonly TModelEntityService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        protected BaseNotEditableController(TModelEntityService service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        /// <summary>
        /// Получить все записи
        /// </summary>
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
