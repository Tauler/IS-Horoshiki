using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class DeliveryTimeModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DeliveryTime ToDaoEntity(this IDeliveryTimeModel model)
        {
            return new DeliveryTime()
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
        public static IEnumerable<DeliveryTime> ToDaoEntityList(this IEnumerable<IDeliveryTimeModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IDeliveryTimeModel ToModelEntity(this DeliveryTime model)
        {
            return new DeliveryTimeModel()
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
        public static IEnumerable<IDeliveryTimeModel> ToModelEntityList(this IEnumerable<DeliveryTime> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
