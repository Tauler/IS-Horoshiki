using System;
using IsHoroshiki.BusinessServices.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using Microsoft.Practices.Unity;

namespace IsHoroshiki.BusinessServices
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

            DAO.Bootstrapper.BuildUnityContainer(container);

            container.RegisterType<IBuyProcessService, BuyProcessService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusSiteService, StatusSiteService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IPositionService, PositionService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeStatusService, EmployeeStatusService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}