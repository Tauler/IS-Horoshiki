using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using IsHoroshiki.WebApi.Controllers;

namespace IsHoroshiki.WebApi.Handlers
{
    /// <summary>
    /// Обработчик, возвращающий результ запроса, обернутый в объект ApiResponse
    /// </summary>
    public class WrappingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            int status = 0;
            object content;
            string errorCode = null;
            string errorMessage = null;

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var errorData = new UnauthorizedErrorData();
                return request.CreateResponse(HttpStatusCode.Unauthorized, new ApiResponse(status, null, errorData.Code, errorData.Message)); ;
            }

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;
                if (error != null)
                {
                    content = null;
                    errorCode = MessageHolder.Instance.GetCode(CommonErrors.Exception);
                    errorMessage = error.Message;

#if DEBUG
                    errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
#endif
                    status = 0;
                }
                else
                {
                    var errorData = content as ErrorData;
                    if (errorData != null)
                    {
                        content = null;
                        errorCode = errorData.Code;
                        errorMessage = errorData.Message;

                        status = 0;
                    }
                }

            }
            else
            {
                status = 1;
            }

            var newResponse = request.CreateResponse(HttpStatusCode.OK, new ApiResponse(status, content, errorCode, errorMessage));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}