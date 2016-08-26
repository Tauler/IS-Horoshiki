using System;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;
using Microsoft.Practices.Unity;
using IsHoroshiki.DAO.Repositories.Accounts;
using IsHoroshiki.DAO.Repositories.Accounts.Interfaces;

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

            container.RegisterType<IBuyProcessRepository, BuyProcessRepository>();
            container.RegisterType<IDeliveryZoneRepository, DeliveryZoneRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<ISubDepartmentRepository, SubDepartmentRepository>();
            container.RegisterType<IEmployeeStatusRepository, EmployeeStatusRepository>();
            container.RegisterType<IOrderStatusRepository, OrderStatusRepository>();
            container.RegisterType<IOrderPayRepository, OrderPayRepository>();
            container.RegisterType<IPositionRepository, PositionRepository>();
            container.RegisterType<IPriceTypeRepository, PriceTypeRepository>();
            container.RegisterType<IStatusSiteRepository, StatusSiteRepository>();
            container.RegisterType<ISubDivisionRepository, SubDivisionRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IDeliveryTimeRepository, DeliveryTimeRepository>();

            return container;
        }
    }
}