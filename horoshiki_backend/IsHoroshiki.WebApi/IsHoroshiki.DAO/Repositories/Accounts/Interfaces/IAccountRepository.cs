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
        /// Получить все записи
        /// </summary>  
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <param name="isLoadChild">true - если нужно загрузить дочерние объекты</param>
        /// <param name="filterLastName">Фильтр по фамилии</param>
        /// <param name="filterIsAccess">Фильтр Доступ в систему</param>
        /// <param name="filterEmployeeStatusId">Фильтр Статус сотрудника</param>
        /// <param name="filterPositionId">Фильтр Должности</param>
        /// <param name="filterDepartmentId">Фильтр Отдел</param>
        /// <param name="filterPlatformId">Фильтр Площадка</param>
        /// <param name="filterIsHaveMedicalBook">Фильтр Наличие мед книжки</param>
        Task<IEnumerable<ApplicationUser>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true, bool isLoadChild = true,
            string filterLastName = "", bool? filterIsAccess = null, int filterEmployeeStatusId = 0, int filterPositionId = 0, int filterDepartmentId = 0,
            int filterPlatformId = 0, bool? filterIsHaveMedicalBook = null);

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

        /// <summary>
        /// Получить всех управляющих
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetAllSmallManager(string sortField = "", bool isAscending = true);

        /// <summary>
        /// Получить всех стажеров
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetAllSmallTrainee(string sortField = "", bool isAscending = true);
    }
}
