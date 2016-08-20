using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IsHoroshiki.WebApi.Startup))]

namespace IsHoroshiki.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
