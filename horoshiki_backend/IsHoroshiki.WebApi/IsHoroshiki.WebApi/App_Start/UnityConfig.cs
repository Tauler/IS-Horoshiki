using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.WebApi
{
    /// <summary>
    /// ������������ Unity
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// true - ���� ��������� ���������������
        /// </summary>
        private static bool _isRegistered;

        /// <summary>
        /// ����������� ���������
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
        /// ����������� ���������
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
        /// ��������� ���������� DependencyResolver
        /// </summary>
        private class UnityDependencyResolver : IDependencyResolver
        {
            /// <summary>
            /// ���������
            /// </summary>
            private readonly IUnityContainer _container;

            /// <summary>
            /// �����������
            /// </summary>
            /// <param name="container"></param>
            public UnityDependencyResolver(IUnityContainer container)
            {
                _container = container;
            }

            /// <summary>
            /// �������� ������
            /// </summary>
            /// <param name="serviceType">���</param>
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
            /// �������� ������
            /// </summary>
            /// <param name="serviceType">���</param>
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