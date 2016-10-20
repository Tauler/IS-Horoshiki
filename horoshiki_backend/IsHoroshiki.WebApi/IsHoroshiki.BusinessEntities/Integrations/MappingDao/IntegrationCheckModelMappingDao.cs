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
                Klient = model.Klient,
                Cook = model.Cook,
                Zona = model.Zona,
                Before = model.Before,
                OrderView = model.OrderView,
                TimeStartCooking = model.TimeStartCooking,
                TimeEndCooking = model.TimeEndCooking,
                DateStartMaking = model.DateStartMaking,
                DateEndMaking = model.DateEndMaking,
                TimeDelivery = model.TimeDelivery,
                DateDelivery = model.DateDelivery,
                Driver = model.Driver,
                Address = model.Address,
                AddressKaldr = model.AddressKaldr,
                CoordinateWidth = model.CoordinateWidth,
                CoordinateLongitude = model.CoordinateWidth,
                IsSushiDepartment = model.IsSushiDepartment,
                IsPizzaDepartment = model.IsPizzaDepartment,
                IsCoolDepartment = model.IsCoolDepartment
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
                Klient = model.Klient,
                Cook = model.Cook,
                Zona = model.Zona,
                Before = model.Before,
                OrderView = model.OrderView,
                TimeStartCooking = model.TimeStartCooking,
                TimeEndCooking = model.TimeEndCooking,
                DateStartMaking = model.DateStartMaking,
                DateEndMaking = model.DateEndMaking,
                TimeDelivery = model.TimeDelivery,
                DateDelivery = model.DateDelivery,
                Driver = model.Driver,
                Address = model.Address,
                AddressKaldr = model.AddressKaldr,
                CoordinateWidth = model.CoordinateWidth,
                CoordinateLongitude = model.CoordinateWidth,
                IsSushiDepartment = model.IsSushiDepartment,
                IsPizzaDepartment = model.IsPizzaDepartment,
                IsCoolDepartment = model.IsCoolDepartment
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
