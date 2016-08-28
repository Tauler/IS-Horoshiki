using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.DAO.Identities;

namespace IsHoroshiki.BusinessEntities.Account.MappingDao
{
    /// <summary>
    /// Меппинг полей сущности DAO на бизнес-сущность
    /// </summary>
    public static class UserModelMappingDao
    {
        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApplicationUser ToDaoEntity(this IUserModel model)
        {
            return new ApplicationUser()
            {
                Id = model.Id,
                UserName = model.UserName
            };
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<ApplicationUser> ToDaoEntityList(this IEnumerable<IUserModel> models)
        {
            return models.Select(model => model.ToDaoEntity());
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static ICollection<ApplicationUser> ToDaoEntityList(this ICollection<IUserModel> models)
        {
            return models.Select(model => model.ToDaoEntity()).ToList();
        }

        /// <summary>
        /// Модель в DAO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IUserModel ToModelEntity(this ApplicationUser model)
        {
            return new UserModel()
            {
                Id = model.Id,
                UserName = model.UserName
            };
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static IEnumerable<IUserModel> ToModelEntityList(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(model => model.ToUserModelEntity());
        }

        /// <summary>
        /// DAO в модель
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static ICollection<IUserModel> ToModelEntityList(this ICollection<ApplicationUser> models)
        {
            return models.Select(model => model.ToUserModelEntity()).ToList();
        }
    }
}
