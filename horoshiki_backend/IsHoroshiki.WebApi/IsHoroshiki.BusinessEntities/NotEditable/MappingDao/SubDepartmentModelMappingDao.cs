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
    public static class SubDepartmentModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static SubDepartment ToDaoEntity(this ISubDepartmentModel model)
        {
            return new SubDepartment()
            {
                Id = model.Id,
                Value = model.Value,
                DepartmentId = model.DepartmentId,
                Department = model.Department?.ToDaoEntity()
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<SubDepartment> ToDaoEntityList(this IEnumerable<ISubDepartmentModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ISubDepartmentModel ToModelEntity(this SubDepartment model)
        {
            return new SubDepartmentModel()
            {
                Id = model.Id,
                Value = model.Value,
                DepartmentId = model.DepartmentId,
                Department = model.Department?.ToModelEntity()
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ISubDepartmentModel> ToModelEntityList(this IEnumerable<SubDepartment> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
