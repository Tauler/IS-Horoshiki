using System;
using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using Microsoft.Practices.Unity;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using IsHoroshiki.BusinessEntities.Integrations;

namespace IsHoroshiki.BusinessEntities
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

            container.RegisterType<IApplicationUserModel, ApplicationUserModel>();
            container.RegisterType<IApplicationUserSmallModel, ApplicationUserSmallModel>();
            container.RegisterType<IPlatformModel, PlatformModel>();
            container.RegisterType<IEmployeeStatusModel, EmployeeStatusModel>();
            container.RegisterType<ISubDivisionModel, SubDivisionModel>();
            container.RegisterType<IEmployeeReasonDismissalModel, EmployeeReasonDismissalModel>();
            container.RegisterType<IDepartmentModel, DepartmentModel>();

            container.RegisterType<IDeliveryZoneTypeModel, DeliveryZoneTypeModel>();
            container.RegisterType<IDeliveryZoneModel, DeliveryZoneModel>();

            container.RegisterType<ISalePlanPeriodModel, SalePlanPeriodModel>();
            container.RegisterType<ISalePlanModel, SalePlanModel>();
            container.RegisterType<ISalePlanDayModel, SalePlanDayModel>();
            container.RegisterType<ISalePlanTableModel, SalePlanTableModel>();
            container.RegisterType<ISalePlanDataRowModel, SalePlanDataRowModel>();
            container.RegisterType<ISalePlanSumDayModel, SalePlanSumDayModel>();
            container.RegisterType<ISalePlanSumRowModel, SalePlanSumRowModel>();
            
            container.RegisterType<IIntegrationCheckModel, IntegrationCheckModel>();
            
            return container;
        }
    }
}