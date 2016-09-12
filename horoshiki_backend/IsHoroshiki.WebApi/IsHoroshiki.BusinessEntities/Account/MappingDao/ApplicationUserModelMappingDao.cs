using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
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
            daoModel.EmployeeStatusId = model.EmployeeStatus != null ? model.EmployeeStatus.Id : 0;
            daoModel.EmployeeStatus = model.EmployeeStatus != null ? model.EmployeeStatus.ToDaoEntity() : null;
            daoModel.PositionId = model.Position != null ? model.Position.Id : 0;
            daoModel.Position = model.Position != null ? model.Position.ToDaoEntity() : null;

            if (model.Platform != null && model.Platform.Id > 0)
            {
                daoModel.Platform = model.Platform.ToDaoEntity();
                daoModel.PlatformId = model.Platform.Id;
            }
            else
            {
                daoModel.PlatformId = null;
                daoModel.Platform = null;
            }

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
        /// <param name="isLoadChild">Конвертировать дочерние объекты</param>
        /// <returns></returns>
        public static IApplicationUserModel ToModelEntity(this ApplicationUser model, bool isLoadChild = true)
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
                Platform = isLoadChild && model.Platform != null ? model.Platform.ToModelEntity(false) : null,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                IsAccess = model.IsAccess,
                UserName = model.UserName,
                Email = model.Email
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserModel> ToModelEntityList(this IEnumerable<ApplicationUser> models, bool isLoadChild = true)
        {
            return models.Select(m => ToModelEntity(m, isLoadChild));
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IApplicationUserSmallModel ToUserSmallModelEntity(this ApplicationUser model)
        {
            return new ApplicationUserSmallModel()
            {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserSmallModel> ToUserSmallModelEntityList(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(ToUserSmallModelEntity);
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IApplicationUserSmallModel ToUserSmallModelEntity(this IApplicationUserModel model)
        {
            return new ApplicationUserSmallModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IApplicationUserSmallModel> ToUserSmallModelEntityList(this IEnumerable<IApplicationUserModel> models)
        {
            return models.Select(ToUserSmallModelEntity);
        }
    }
}
