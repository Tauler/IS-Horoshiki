using System;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.BusinessServices.NotEditableDictionaries;
using IsHoroshiki.DAO.UnitOfWorks;
using Microsoft.Practices.Unity;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.NotEditable;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.Utils.Interfaces;
using IsHoroshiki.BusinessServices.Validators.Editable;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

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

            container.RegisterType<IAccountValidator, AccountValidator>();
            container.RegisterType<ISubDivisionValidator, SubDivisionValidator>();
            container.RegisterType<IPlatformValidator, PlatformValidator>();

            container.RegisterType<IBuyProcessService, BuyProcessService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlatformStatusService, PlatformStatusService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlatformService, PlatformService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IPositionService, PositionService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeStatusService, EmployeeStatusService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubDepartmentService, SubDepartmentService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderStatusService, OrderStatusService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderPayService, OrderPayService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubDivisionService, SubDivisionService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IPriceTypeService, PriceTypeService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeliveryZoneService, DeliveryZoneService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeliveryTimeService, DeliveryTimeService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUtilService, UtilService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountService, AccountService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}