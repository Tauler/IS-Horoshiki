using System;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices;
using IsHoroshiki.BusinessServices.Helpers;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Абстрактный класс редактируемого контроллера
    /// </summary>
    public class BaseEditableController<TModelEntity> : BaseController<TModelEntity>
        where TModelEntity : class, IBaseBusninessModel
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        protected readonly IBaseEditableService<TModelEntity> _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        protected BaseEditableController(IBaseEditableService<TModelEntity> service)
            : base(service)
        {
            _service = service;
        }

        #endregion

        #region методы

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            try
            {
                var t = typeof(PagedResult<TModelEntity>);
                var list = await _service.GetAllAsync(pageNo, pageSize, sortField, isAscending);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetAllMessages());
            }
        }

        /// <summary>
        /// Добавить в БД
        /// </summary>
        /// <param name="model">Данные</param>
        [Route("Add")]
        public virtual async Task<IHttpActionResult> Add(TModelEntity model)
        {
            if (!ModelState.IsValid)
            {
                return GetErrorResult(ModelState);
            }

            try
            {
                ModelEntityModifyResult result = await _service.AddAsync(model);
                if (!result.IsValidationSucceeded || !result.IsSucceeded)
                {
                    return BadRequest(result.GetAllMessages());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.GetAllMessages());
            }

            return Ok();
        }

        #endregion
    }
}
