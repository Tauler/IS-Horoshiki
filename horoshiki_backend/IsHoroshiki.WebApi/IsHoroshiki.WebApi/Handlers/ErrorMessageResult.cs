using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using IsHoroshiki.BusinessServices.Helpers;

namespace IsHoroshiki.WebApi.Handlers
{
    /// <summary>
    /// Возврат кастомный ошибки
    /// </summary>
    public class ErrorMessageResult : IHttpActionResult
    {
        /// <summary>
        /// Ошибка с описанием
        /// </summary>
        private readonly ErrorData _error;

        #region Конструктор 

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="errors">Ошибки с описанием</param>
        public ErrorMessageResult(IEnumerable<ErrorData> errors)
        {
            if (errors != null)
            {
                this._error = errors.FirstOrDefault();
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="error">Ошибка с описанием</param>
        public ErrorMessageResult(ErrorData error)
        {
            this._error = error;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="error">Ошибка с описанием</param>
        public ErrorMessageResult(string error)
        {
            this._error = new ErrorData(CommonErrors.Exception, error);
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="error">Ошибка с описанием</param>
        public ErrorMessageResult(Exception error)
        {
            this._error = new ErrorData(CommonErrors.Exception, error.GetAllMessages());
        }

        #endregion

        /// <summary>
        /// Формирование ответа
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<ErrorData>(_error, new JsonMediaTypeFormatter())
            };
            return Task.FromResult(response);
        }
    }
}