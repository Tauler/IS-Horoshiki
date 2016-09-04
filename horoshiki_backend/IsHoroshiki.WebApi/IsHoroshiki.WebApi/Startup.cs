using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IsHoroshiki.WebApi.Startup))]

namespace IsHoroshiki.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
