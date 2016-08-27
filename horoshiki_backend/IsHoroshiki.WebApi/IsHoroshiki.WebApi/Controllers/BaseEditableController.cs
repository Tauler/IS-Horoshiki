using System;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessServices;
using IsHoroshiki.BusinessServices.Helpers;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Абстрактный класс редактируемого контроллера
    /// </summary>
    public class BaseEditableController<TModelEnty> : BaseController<TModelEnty>
        where TModelEnty : class, IBaseBusninessModel
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        protected readonly IBaseEditableService<TModelEnty> _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        protected BaseEditableController(IBaseEditableService<TModelEnty> service)
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
                var list = await _service.GetAllAsync(pageNo, pageSize, sortField, isAscending);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetAllMessages());
            }
        }

        #endregion
    }
}
