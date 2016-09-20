using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class OrderStatusModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderStatus ToDaoEntity(this IOrderStatusModel model)
        {
            return new OrderStatus()
            {
                Id = model.Id,
                Guid = model.Guid,
                Value = model.Value
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<OrderStatus> ToDaoEntityList(this IEnumerable<IOrderStatusModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IOrderStatusModel ToModelEntity(this OrderStatus model)
        {
            return new OrderStatusModel()
            {
                Id = model.Id,
                Guid = model.Guid,
                Value = model.Value
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IOrderStatusModel> ToModelEntityList(this IEnumerable<OrderStatus> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
