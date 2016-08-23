﻿using System;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;
using Microsoft.Practices.Unity;
using IsHoroshiki.DAO.Accounts.Interfaces;
using IsHoroshiki.DAO.Repositories.Accounts;

namespace IsHoroshiki.DAO
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

            container.RegisterType<IBuyProcessRepository, BuyProcessRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeliveryZoneRepository, DeliveryZoneRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentRepository, DepartmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubDepartmentRepository, SubDepartmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeStatusRepository, EmployeeStatusRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderStatusRepository, OrderStatusRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPositionRepository, PositionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPriceTypeRepository, PriceTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusSiteRepository, StatusSiteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubDivisionRepository, SubDivisionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeliveryTimeRepository, DeliveryTimeRepository>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}