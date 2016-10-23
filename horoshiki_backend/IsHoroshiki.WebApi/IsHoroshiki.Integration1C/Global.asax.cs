using IsHoroshiki.BusinessServices.Integrations.Queues;
using IsHoroshiki.Integration1C.LogHandler;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IsHoroshiki.Integration1C
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiLogHandler());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IntegrationCheckQueue.Instance.Load();
            IntegrationCheckQueue.Instance.Start();
        }
    }
}
