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

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

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
    }
}