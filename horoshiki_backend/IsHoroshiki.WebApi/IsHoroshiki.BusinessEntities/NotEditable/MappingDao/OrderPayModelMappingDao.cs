using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class OrderPayModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderPay ToDaoEntity(this IOrderPayModel model)
        {
            return new OrderPay()
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
        public static IEnumerable<OrderPay> ToDaoEntityList(this IEnumerable<IOrderPayModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IOrderPayModel ToModelEntity(this OrderPay model)
        {
            return new OrderPayModel()
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
        public static IEnumerable<IOrderPayModel> ToModelEntityList(this IEnumerable<OrderPay> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
