using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Identities;
using Microsoft.AspNet.Identity;

namespace IsHoroshiki.DAO.Repositories.Accounts.Interfaces
{
    /// <summary>
    /// Репозитарий авторизации
    /// </summary>
    public interface IAccountRepository : IDisposable
    {
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true);

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <returns></returns>
        Task<ApplicationUser> GetByIdAsync(int id);

        /// <summary>
        /// Количество всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterAsync(ApplicationUser user, string password);

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        Task<IdentityResult> UpdateAsync(ApplicationUser user);

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="user">Пользователь</param>
        Task<IdentityResult> DeleteAsync(ApplicationUser user);

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
    }
}
