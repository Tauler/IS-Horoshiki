using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net;
using IsHoroshiki.WebApi.Helpers;

namespace IsHoroshiki.WebApi.ActionFilters
{
    /// <summary>
    /// Глобальный обработчик ошибок
    /// </summary>
    public class GlobalExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Ошибка
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLoggerHelper());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Error(context.Request, "Controller : " + context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + context.ActionContext.ActionDescriptor.ActionName, context.Exception);
        }
    }
}