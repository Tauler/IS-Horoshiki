using System;
using Microsoft.Practices.Unity;
using IsHoroshiki.DAO.Kladr.Repositories;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Регистрация в IoC контейнере
        /// </summary>
        /// <param name="container">IoC контейнер</param>
        /// <returns></returns>
        public static IUnityContainer BuildUnityContainer(UnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }

            container.RegisterType<IAltNameRepository, AltNameRepository>();
            container.RegisterType<IDomaRepository, DomaRepository>();
            container.RegisterType<IFlatRepository, FlatRepository>();
            container.RegisterType<IKladrRepository, KladrRepository>();
            container.RegisterType<ISocrbaseRepository, SocrbaseRepository>();
            container.RegisterType<IStreetRepository, StreetRepository>();

            return container;
        }
    }
}