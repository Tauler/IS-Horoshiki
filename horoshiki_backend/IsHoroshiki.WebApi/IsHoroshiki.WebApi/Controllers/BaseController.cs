using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
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
        /// true - если был вызван Dispose
        /// </summary>
        private bool _disposed;

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
        public virtual async Task<IHttpActionResult> GetById(int id)
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

        #region protected

        /// <summary>
        /// Вернуть первую ошибку валидации модели
        /// </summary>
        /// <param name="modelState">Словарь ошибок</param>
        /// <returns></returns>
        protected IHttpActionResult GetErrorResult(ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                return InternalServerError();
            }

            if (!modelState.IsValid)
            {
                foreach (var modelStateError in modelState.Values)
                {
                    foreach (var error in modelStateError.Errors)
                    {
                        if (!string.IsNullOrEmpty(error.ErrorMessage))
                        {
                            return BadRequest(error.ErrorMessage);
                        }

                        if (error.Exception != null)
                        {
                            return BadRequest(error.Exception.Message);
                        }
                    }
                }

                return BadRequest(ModelState);
            }

            return null;
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
