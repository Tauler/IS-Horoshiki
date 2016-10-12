using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class DeliveryZoneModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DeliveryZoneType ToDaoEntity(this IDeliveryZoneTypeModel model)
        {
            return new DeliveryZoneType()
            {
                Id = model.Id,
                Guid = model.Guid,
                Time = model.Time,
                Background = model.Background,
                BorderColor = model.BorderColor,
                Opacity = model.Opacity,
                Value = model.Value
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<DeliveryZoneType> ToDaoEntityList(this IEnumerable<IDeliveryZoneTypeModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IDeliveryZoneTypeModel ToModelEntity(this DeliveryZoneType model)
        {
            return new DeliveryZoneTypeModel()
            {
                Id = model.Id,
                Guid = model.Guid,
                Time = model.Time,
                Background = model.Background,
                BorderColor = model.BorderColor,
                Opacity = model.Opacity,
                Value = model.Value
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IDeliveryZoneTypeModel> ToModelEntityList(this IEnumerable<DeliveryZoneType> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
