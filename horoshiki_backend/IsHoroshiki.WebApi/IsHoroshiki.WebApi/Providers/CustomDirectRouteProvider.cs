using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace IsHoroshiki.WebApi.Providers
{
    /// <summary>
    /// Провайдер наследования атрибутов маршрутизации
    /// </summary>
    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        /// <summary>
        /// Фабрика маршрутизации
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            // inherit route attributes decorated on base class controller's actions
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
        }
    }
}