using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class PositionModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Position ToDaoEntity(this PositionModel model)
        {
            return new Position()
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
        public static IEnumerable<Position> ToDaoEntityList(this IEnumerable<PositionModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PositionModel ToModelEntity(this Position model)
        {
            return new PositionModel()
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
        public static IEnumerable<PositionModel> ToModelEntityList(this IEnumerable<Position> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
