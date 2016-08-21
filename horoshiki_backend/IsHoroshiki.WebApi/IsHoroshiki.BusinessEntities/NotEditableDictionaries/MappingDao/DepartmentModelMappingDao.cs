using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class DepartmentModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Department ToDaoEntity(this IDepartmentModel model)
        {
            return new Department()
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
        public static IEnumerable<Department> ToDaoEntityList(this IEnumerable<IDepartmentModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IDepartmentModel ToModelEntity(this Department model)
        {
            return new DepartmentModel()
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
        public static IEnumerable<IDepartmentModel> ToModelEntityList(this IEnumerable<Department> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
