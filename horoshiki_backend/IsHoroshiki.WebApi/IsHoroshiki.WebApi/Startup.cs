using System;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.WebApi.Models;
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
