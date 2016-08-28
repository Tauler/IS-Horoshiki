using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace IsHoroshiki.WebApi
{
    /// <summary>
    /// Конфигурация Unity
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Регистрация компонент
        /// </summary>
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC  
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        /// <summary>
        /// Регистрация компонент
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            BusinessEntities.Bootstrapper.BuildUnityContainer(container);
            BusinessServices.Bootstrapper.BuildUnityContainer(container);

            return container;
        }
    }
}