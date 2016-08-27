using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.DAO.Identities;
using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditable.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class ApplicationUserModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApplicationUser ToDaoEntity(this IApplicationUserModel model)
        {
            return new ApplicationUser()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Phone = model.Phone,
                IsHaveMedicalBook = model.IsHaveMedicalBook,
                MedicalBookEnd = model.MedicalBookEnd,
                EmployeeStatusId = model.EmployeeStatus != null ? model.EmployeeStatus.Id : 0,
                EmployeeStatus = model.EmployeeStatus != null ? model.EmployeeStatus.ToDaoEntity() : null,
                PositionId = model.Position != null ? model.Position.Id : 0,
                Position = model.Position != null ? model.Position.ToDaoEntity() : null,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsAccess = model.IsAccess,
                UserName = model.UserName
            };
        }

        /// <summary>
        /// Обновить поля в DAO модели
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void Update(this ApplicationUser daoModel, IApplicationUserModel model)
        {
            daoModel.Id = model.Id;
            daoModel.FirstName = model.FirstName;
            daoModel.MiddleName = model.MiddleName;
            daoModel.LastName = model.LastName;
            daoModel.Phone = model.Phone;
            daoModel.IsHaveMedicalBook = model.IsHaveMedicalBook;
            daoModel.MedicalBookEnd = model.MedicalBookEnd;
            daoModel.EmployeeStatusId = model.EmployeeStatus != null ? model.EmployeeStatus.Id : 0;
            daoModel.EmployeeStatus = model.EmployeeStatus != null ? model.EmployeeStatus.ToDaoEntity() : null;
            daoModel.PositionId = model.Position != null ? model.Position.Id : 0;
            daoModel.Position = model.Position != null ? model.Position.ToDaoEntity() : null;
            daoModel.DateStart = model.DateStart;
            daoModel.DateEnd = model.DateEnd;
            daoModel.IsAccess = model.IsAccess;
            daoModel.UserName = model.UserName;
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ApplicationUser> ToDaoEntityList(this IEnumerable<IApplicationUserModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IApplicationUserModel ToModelEntity(this ApplicationUser model)
        {
            return new ApplicationUserModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Phone = model.Phone,
                IsHaveMedicalBook = model.IsHaveMedicalBook,
                MedicalBookEnd = model.MedicalBookEnd,
                EmployeeStatus = model.EmployeeStatus != null ? model.EmployeeStatus.ToModelEntity() : null,
                Position = model.Position != null ? model.Position.ToModelEntity() : null,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsAccess = model.IsAccess,
                UserName = model.UserName
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserModel> ToModelEntityList(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(model => model.ToModelEntity());
        }
    }
}
