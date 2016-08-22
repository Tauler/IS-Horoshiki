using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
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
            string errorMessage = null;

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;

                if (error != null)
                {
                    content = null;
                    errorMessage = error.Message;

#if DEBUG
                    errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
#endif
                    status = 0;
                }
            }
            else
            {
                status = 1;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return response;
            }

            var newResponse = request.CreateResponse(HttpStatusCode.OK, new ApiResponse(status, content, errorMessage));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}