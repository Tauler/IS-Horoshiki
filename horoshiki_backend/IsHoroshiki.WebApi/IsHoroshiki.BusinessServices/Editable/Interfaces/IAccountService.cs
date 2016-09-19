using System.Security.Claims;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    ///  Сервис аккаунтов
    /// </summary>
    public interface IAccountService : IBaseEditableService<IApplicationUserModel>
    {
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<IEnumerable<IApplicationUserSmallModel>> GetAllSmall(string sortField = "", bool isAscending = true);

        /// <summary>
        /// Получить всех управляющих
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<IEnumerable<IApplicationUserSmallModel>> GetAllSmallManager(string sortField = "", bool isAscending = true);

        /// <summary>
        /// Проверка существования логина для пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        Task<bool> IsExistUserName(string userName);

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
        /// <param name="confirmPassword">Подтверждение пароля</param>
        /// <returns></returns>
        Task<IdentityResult> ChangePasswordUserAsync(int userId, string newPassword, string confirmPassword);

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
    }
}
