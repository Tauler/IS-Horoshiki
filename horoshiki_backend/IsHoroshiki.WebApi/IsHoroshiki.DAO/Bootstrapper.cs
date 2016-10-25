using System;
using Microsoft.Practices.Unity;
using IsHoroshiki.DAO.Repositories.Accounts;
using IsHoroshiki.DAO.Repositories.Accounts.Interfaces;
using IsHoroshiki.DAO.Repositories.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.Repositories.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using IsHoroshiki.DAO.Repositories.Integrations;

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
            container.RegisterType<IDeliveryTimeRepository, DeliveryTimeRepository>();
            container.RegisterType<IDeliveryZoneRepository, DeliveryZoneRepository>();
            container.RegisterType<IDeliveryZoneTypeRepository, DeliveryZoneTypeRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<ISubDepartmentRepository, SubDepartmentRepository>();
            container.RegisterType<IEmployeeReasonDismissalRepository, EmployeeReasonDismissalRepository>();
            container.RegisterType<IEmployeeStatusRepository, EmployeeStatusRepository>();
            container.RegisterType<IOrderStatusRepository, OrderStatusRepository>();
            container.RegisterType<IOrderPayRepository, OrderPayRepository>();
            container.RegisterType<IPositionRepository, PositionRepository>();
            container.RegisterType<IPriceTypeRepository, PriceTypeRepository>();
            container.RegisterType<IPlatformStatusRepository, PlatformStatusRepository>();
            container.RegisterType<ISubDivisionRepository, SubDivisionRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IPlatformRepository, PlatformRepository>();

            container.RegisterType<IIntegrationCheckRepository, IntegrationCheckRepository>();
            container.RegisterType<ISaleCheckRepository, SaleCheckRepository>();
            container.RegisterType<ISalePlanRepository, SalePlanRepository>();
            container.RegisterType<ISalePlanDayRepository, SalePlanDayRepository>();
            

            return container;
        }
    }
}