using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class ShiftTypeModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ShiftType ToDaoEntity(this IShiftTypeModel model)
        {
            return new ShiftType()
            {
                Id = model.Id,
                Guid = model.Guid,
                Value = model.Value,
                Socr = model.Socr
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ShiftType> ToDaoEntityList(this IEnumerable<IShiftTypeModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IShiftTypeModel ToModelEntity(this ShiftType model)
        {
            return new ShiftTypeModel()
            {
                Id = model.Id,
                Guid = model.Guid,
                Value = model.Value,
                Socr = model.Socr
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IShiftTypeModel> ToModelEntityList(this IEnumerable<ShiftType> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
