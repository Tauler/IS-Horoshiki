using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class OrderSettingModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderSetting ToDaoEntity(this IOrderSettingModel model)
        {
            return new OrderSetting()
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
        public static IEnumerable<OrderSetting> ToDaoEntityList(this IEnumerable<IOrderSettingModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IOrderSettingModel ToModelEntity(this OrderSetting model)
        {
            return new OrderSettingModel()
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
        public static IEnumerable<IOrderSettingModel> ToModelEntityList(this IEnumerable<OrderSetting> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
