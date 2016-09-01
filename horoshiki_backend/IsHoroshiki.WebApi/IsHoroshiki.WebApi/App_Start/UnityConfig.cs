using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.WebApi
{
    /// <summary>
    /// Конфигурация Unity
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// true - если контейнер зарегистрирован
        /// </summary>
        private static bool _isRegistered;

        /// <summary>
        /// Регистрация компонент
        /// </summary>
        public static void RegisterComponents()
        {
            if (_isRegistered)
            {
                return;
            }
            _isRegistered = true;

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

        /// <summary>
        /// Кастомная реализация DependencyResolver
        /// </summary>
        private class UnityDependencyResolver : IDependencyResolver
        {
            /// <summary>
            /// Контейнер
            /// </summary>
            private readonly IUnityContainer _container;

            /// <summary>
            /// Констурктор
            /// </summary>
            /// <param name="container"></param>
            public UnityDependencyResolver(IUnityContainer container)
            {
                _container = container;
            }

            /// <summary>
            /// Получить сервис
            /// </summary>
            /// <param name="serviceType">Тип</param>
            /// <returns></returns>
            public object GetService(Type serviceType)
            {
                try
                {
                    return _container.Resolve(serviceType);
                }
                catch
                {
                    return null;
                }
            }

            /// <summary>
            /// Получить сервис
            /// </summary>
            /// <param name="serviceType">Тип</param>
            /// <returns></returns>
            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return _container.ResolveAll(serviceType);
                }
                catch
                {
                    return new List<object>();
                }
            }
        }
    }
}