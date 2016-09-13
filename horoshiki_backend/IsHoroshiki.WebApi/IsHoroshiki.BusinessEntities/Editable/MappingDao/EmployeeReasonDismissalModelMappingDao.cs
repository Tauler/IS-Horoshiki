using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable.MappingDao
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
                Name = model.Name
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
                Name = model.Name
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

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="daoModel"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static EmployeeReasonDismissal Update(this EmployeeReasonDismissal daoModel, IEmployeeReasonDismissalModel model)
        {
            daoModel.Id = model.Id;
            daoModel.Name = model.Name;
            return daoModel;
        }
    }
}
