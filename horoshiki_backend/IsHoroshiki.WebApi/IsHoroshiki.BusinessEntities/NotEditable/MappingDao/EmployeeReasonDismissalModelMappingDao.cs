using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class EmployeeReasonDismissalModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static EmployeeReasonDismissal ToDaoEntity(this IEmployeeReasonDismissalModel model)
        {
            return new EmployeeReasonDismissal()
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
        public static IEnumerable<EmployeeReasonDismissal> ToDaoEntityList(this IEnumerable<IEmployeeReasonDismissalModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEmployeeReasonDismissalModel ToModelEntity(this EmployeeReasonDismissal model)
        {
            return new EmployeeReasonDismissalModel()
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
        public static IEnumerable<IEmployeeReasonDismissalModel> ToModelEntityList(this IEnumerable<EmployeeReasonDismissal> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
