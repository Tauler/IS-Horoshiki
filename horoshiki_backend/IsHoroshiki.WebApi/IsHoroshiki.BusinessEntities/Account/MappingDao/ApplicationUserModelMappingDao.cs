using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Accounts;

namespace IsHoroshiki.BusinessEntities.Account.MappingDao
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
            var daoUser = new ApplicationUser();
            Update(daoUser, model);
            return daoUser;
        }

        /// <summary>
        /// Обновить поля в DAO модели
        /// </summary>
        /// <param name="daoModel"></param>
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
            daoModel.EmployeeStatusId = model.EmployeeStatusId;
            daoModel.PositionId = model.PositionId;
            daoModel.DateStart = model.DateStart;
            daoModel.DateEnd = model.DateEnd;
            daoModel.IsAccess = model.IsAccess;
            daoModel.UserName = model.UserName;
            daoModel.Email = model.Email;
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
                EmployeeStatusId = model.EmployeeStatusId,
                PositionId = model.PositionId,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsAccess = model.IsAccess,
                UserName = model.UserName,
                Email = model.Email
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IApplicationUserSmallModel ToSmallModelEntity(this IApplicationUserModel model)
        {
            return new ApplicationUserSmallModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserSmallModel> ToSmallModelEntityList(this IEnumerable<IApplicationUserModel> models)
        {
            return models.Select(ToSmallModelEntity);
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserModel> ToModelEntityList(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(ToModelEntity);
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IApplicationUserSmallModel ToUserModelEntity(this ApplicationUser model)
        {
            return new ApplicationUserSmallModel()
            {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserSmallModel> ToUserModelEntityList(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(ToUserModelEntity);
        }
    }
}
