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

            using (var u = new UnitOfWork())
            {
                u.BuyProcessPepository.Insert(new BuyProcess()
                {
                    Value = DateTime.Now.ToLongTimeString()
                });

                u.StatusSiteRepository.Insert(new StatusSite()
                {
                    Value = DateTime.Now.ToLongTimeString()
                });

                u.PositionRepository.Insert(new Position()
                {
                    Value = DateTime.Now.ToLongTimeString()
                });

                u.Save();
            }
        }
    }
}
