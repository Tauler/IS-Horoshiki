using System.Web.Http;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.WebApi.Handlers;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using Newtonsoft.Json;
using System;

namespace IsHoroshiki.WebApi
{
    /// <summary>
    /// Конфигурация контроллеров
    /// </summary>
    public static class ControllerConfig
    {
        /// <summary>
        /// Регистрация биндинга интерфйса на сущность  для контроллера
        /// </summary>
        public static void Register()
        {
            RegisterConverter<IApplicationUserModel>();
            RegisterConverter<ISubDivisionModel>();
            RegisterConverter<IPlatformModel>();
            RegisterConverter<IEmployeeReasonDismissalModel>();
            RegisterConverter<IDepartmentModel>();
            RegisterConverter<IDeliveryZoneModel>();
            RegisterConverter<ISalePlanModel>();
            RegisterConverter<ISalePlanDayModel>();
            RegisterConverter<IShiftPersonalModel>();
            RegisterConverter<IShiftPersonalTimePartModel>();
            RegisterConverter<IMonthObjectiveModel>();
            RegisterConverter<IShiftPersonalScheduleModel>();
            RegisterConverter<IShiftPersonalScheduleDataModel>();
        }

        private static void RegisterConverter<T>()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IocCustomCreationConverter<T>());
        }
    }
}
