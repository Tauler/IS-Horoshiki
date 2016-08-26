using IsHoroshiki.BusinessEntities.Paging;
using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Account.Interfaces;

namespace IsHoroshiki.BusinessServices.Account.Interfaces
{
    /// <summary>
    ///  Сервис аккаунтов
    /// </summary>
    public interface IAccountService : IDisposable
    {
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<PagedResult<IApplicationUserModel>> GetAll(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true);

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <returns></returns>
        Task<IApplicationUserModel> GetByIdAsync(int id);

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="userModel">Пользователь</param>
        /// <returns></returns>
        Task<IdentityResult> RegisterAsync(IApplicationUserModel userModel);

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="userModel">Пользователь</param>
        /// <returns></returns>
        Task<IdentityResult> UpdateAsync(IApplicationUserModel userModel);

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        Task<IdentityResult> DeleteAsync(int id);

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
