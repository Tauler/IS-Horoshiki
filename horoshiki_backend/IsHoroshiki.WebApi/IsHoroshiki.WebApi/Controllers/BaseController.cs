using System;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessServices;
using IsHoroshiki.BusinessServices.Helpers;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Абстрактный класс контроллера
    /// </summary>
    public abstract class BaseController<TModelEntity> : ApiController
        where TModelEntity : IBaseBusninessModel
    {
        #region поля и свойства

        /// <summary>
        /// Сервис бизнес-логики
        /// </summary>
        private readonly IBaseBusinessService<TModelEntity> _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис бизнес-логики</param>
        protected BaseController(IBaseBusinessService<TModelEntity> service)
        {
            _service = service;
        }

        #endregion

        #region методы

        /// <summary>  
        /// Найти по Id 
        /// </summary>  
        /// <param name="id">Id</param>  
        [Route("{id}")]
        public virtual async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var modelEntity = await this._service.GetByIdAsync(id);
                if (modelEntity != null)
                {
                    return Ok(modelEntity);
                }
                else
                {
                    return Ok($"Объект с указанным Id={id} не найден!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.GetAllMessages());
            }
        }

        #endregion
    }
}
