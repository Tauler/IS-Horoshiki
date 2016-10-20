using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.DaoEntities.Integrations;

namespace IsHoroshiki.BusinessEntities.Integrations.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class IntegrationCheckModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IntegrationCheck ToDaoEntity(this IIntegrationCheckModel model)
        {
            return new IntegrationCheck()
            {
                Cmd = model.Cmd,
                IdCheck = model.Id,
                DateDoc = model.DateDoc,
                Status = model.Status,
                Client = model.Client,
                Cook = model.Cook,
                Zona = model.Zona,
                Before = model.Before,
                OrderView = model.OrderView,
                PlanCookingTimeStart = model.PlanCookingTimeStart,
                PlanCookingTimeEnd = model.PlanCookingTimeEnd,
                PlanCookingDateStart = model.PlanCookingDateStart,
                PlanCookingDateEnd = model.PlanCookingDateEnd,
                TimeDelivery = model.TimeDelivery,
                DateDelivery = model.DateDelivery,
                Driver = model.Driver,
                Address = model.Address,
                AddressKaldr = model.AddressKaldr,
                CoordinateWidth = model.CoordinateWidth,
                CoordinateLongitude = model.CoordinateWidth,
                IsSushiSubDepartment = model.IsSushiSubDepartment,
                IsPizzaSubDepartment = model.IsPizzaSubDepartment,
                IsCoolSubDepartment = model.IsCoolSubDepartment
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IntegrationCheck> ToDaoEntityList(this IEnumerable<IIntegrationCheckModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IIntegrationCheckModel ToModelEntity(this IntegrationCheck model)
        {
            return new IntegrationCheckModel()
            {
                Cmd = model.Cmd,
                Id = model.IdCheck,
                DateDoc = model.DateDoc,
                Status = model.Status,
                Client = model.Client,
                Cook = model.Cook,
                Zona = model.Zona,
                Before = model.Before,
                OrderView = model.OrderView,
                PlanCookingTimeStart = model.PlanCookingTimeStart,
                PlanCookingTimeEnd = model.PlanCookingTimeEnd,
                PlanCookingDateStart = model.PlanCookingDateStart,
                PlanCookingDateEnd = model.PlanCookingDateEnd,
                TimeDelivery = model.TimeDelivery,
                DateDelivery = model.DateDelivery,
                Driver = model.Driver,
                Address = model.Address,
                AddressKaldr = model.AddressKaldr,
                CoordinateWidth = model.CoordinateWidth,
                CoordinateLongitude = model.CoordinateWidth,
                IsSushiSubDepartment = model.IsSushiSubDepartment,
                IsPizzaSubDepartment = model.IsPizzaSubDepartment,
                IsCoolSubDepartment = model.IsCoolSubDepartment
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IIntegrationCheckModel> ToModelEntityList(this IEnumerable<IntegrationCheck> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
