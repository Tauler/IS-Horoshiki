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
    public static class PlatformStatusModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static PlatformStatus ToDaoEntity(this IPlatformStatusModel model)
        {
            return new PlatformStatus()
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
        public static IEnumerable<PlatformStatus> ToDaoEntityList(this IEnumerable<IPlatformStatusModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IPlatformStatusModel ToModelEntity(this PlatformStatus model)
        {
            return new PlatformStatusModel()
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
        public static IEnumerable<IPlatformStatusModel> ToModelEntityList(this IEnumerable<PlatformStatus> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
