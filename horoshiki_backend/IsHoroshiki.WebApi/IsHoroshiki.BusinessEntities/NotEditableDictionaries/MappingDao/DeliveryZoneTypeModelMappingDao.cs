using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class DeliveryZoneTypeModelMappingDao
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
