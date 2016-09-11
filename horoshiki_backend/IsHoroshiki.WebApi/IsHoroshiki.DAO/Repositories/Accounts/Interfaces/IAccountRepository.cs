using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IsHoroshiki.DAO.DaoEntities.Accounts;
using Microsoft.AspNet.Identity;

namespace IsHoroshiki.DAO.Repositories.Accounts.Interfaces
{
    /// <summary>
    /// Репозитарий авторизации
    /// </summary>
    public interface IAccountRepository : IBaseRepository<ApplicationUser>
    {
        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<IdentityResult> InsertAsync(ApplicationUser entity, string password);

        /// <summary>
        /// Найти пользоватея
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        Task<ApplicationUser> FindByNameAsync(string userName);

        /// <summary>
        /// Найти пользоватея
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<IUser<int>> FindAsync(string userName, string password);

        /// <summary>
        /// Создание Identity пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType">Тип аутентификации</param>
        /// <returns></returns>
        Task<ClaimsIdentity> GenerateUserIdentityAsync(IUser<int> user, string authenticationType);

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        Task<IdentityResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword);


        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        Task<IdentityResult> ChangePasswordAsync(int userId, string newPassword);

        /// <summary>
        /// Установить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        Task<IdentityResult> AddPasswordAsync(int userId, string newPassword);

        /// <summary>
        /// Удалить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        Task<IdentityResult> RemovePasswordAsync(int userId);

        /// <summary>
        /// Удалить логин
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns></returns>
        Task<IdentityResult> RemoveLoginAsync(int userId, string loginProvider, string providerKey);

        /// <summary>
        /// true - если существует площадка для пользователя
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <returns></returns>
        bool IsExistForPlatform(int platformId);
    }
}
