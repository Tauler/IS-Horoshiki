using System;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Tracing;
using System.Web.Http;
using IsHoroshiki.WebApi.Helpers;

namespace IsHoroshiki.WebApi.ActionFilters
{
    /// <summary>
    /// Аттрибут логиирование
    /// </summary>
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// На выполнение метода
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLoggerHelper());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Info(filterContext.Request, "Controller : " + filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.ActionName, "JSON", filterContext.ActionArguments);
        }
    }
}