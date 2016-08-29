using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Account.MappingDao;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using Microsoft.AspNet.Identity;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис аккаунтов
    /// </summary>
    public class AccountService :  IAccountService
    {
        #region поля и свойства

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        protected bool _disposed;

        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        public AccountService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        #region IAccountService

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public async Task<PagedResult<IApplicationUserModel>> GetAll(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            if (string.Equals(sortField, "EmployeeStatus") || string.Equals(sortField, "Position"))
            {
                sortField += "Id";
            }

            var count = await _unitOfWork.AccountRepository.CountAsync();
            var list = await _unitOfWork.AccountRepository.GetAllAsync(pageNo, pageSize, sortField, isAscending);
            return new PagedResult<IApplicationUserModel>(ApplicationUserModelMappingDao.ToModelEntityList(list), pageNo, pageSize, count);
        }

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <returns></returns>
        public async Task<IApplicationUserModel> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (user != null)
            {
                return ApplicationUserModelMappingDao.ToModelEntity(user);
            }

            return null;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="userModel">пользователь</param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterAsync(IApplicationUserModel userModel)
        {
            var error = await Validation(userModel, true);
            if (!string.IsNullOrEmpty(error))
            {
                return new IdentityResult(error);
            }

            var daoUser = userModel.ToDaoEntity();
            daoUser.EmployeeStatus = null;
            daoUser.Platforms = null;
            daoUser.Position = null;

            return await _unitOfWork.AccountRepository.RegisterAsync(userModel.ToDaoEntity(), userModel.Password);
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="userModel">Пользователь</param>
        /// <returns></returns>
        public async Task<IdentityResult> UpdateAsync(IApplicationUserModel userModel)
        {
            try
            {
                var error = await Validation(userModel, false);
                if (!string.IsNullOrEmpty(error))
                {
                    return new IdentityResult(error);
                }

                var daoUser = await _unitOfWork.AccountRepository.GetByIdAsync(userModel.Id);
                if (daoUser == null)
                {
                    return new IdentityResult(ResourceBusinessServices.AccountsController_UserNotFound);
                }

                daoUser.Update(userModel);
                daoUser.EmployeeStatus = null;
                daoUser.Position = null;

                return await _unitOfWork.AccountRepository.UpdateAsync(daoUser);
            }
            catch (Exception e)
            {
                return new IdentityResult(ResourceBusinessServices.AccountsController_UserUpdateError);
            }
        }

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="id">Id пользователя</param>
        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var user = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (user == null)
            {
                return new IdentityResult(ResourceBusinessServices.AccountsController_UserNotFound);
            }

            return await _unitOfWork.AccountRepository.DeleteAsync(user);
        }

        /// <summary>
        /// Проверка существования логина для пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <returns></returns>
        public async Task<bool> IsExistUserName(string userName)
        {
            var user = await _unitOfWork.AccountRepository.FindByNameAsync(userName);
            return user != null;
        }

        /// <summary>
        /// Найти пользоватея
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public Task<IUser<int>> FindAsync(string userName, string password)
        {
            return _unitOfWork.AccountRepository.FindAsync(userName, password);
        }

        /// <summary>
        /// Создание Identity пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType">Тип аутентификации</param>
        /// <returns></returns>
        public Task<ClaimsIdentity> GenerateUserIdentityAsync(IUser<int> user, string authenticationType)
        {
            return _unitOfWork.AccountRepository.GenerateUserIdentityAsync(user, authenticationType);
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public Task<IdentityResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            return _unitOfWork.AccountRepository.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public Task<IdentityResult> AddPasswordAsync(int userId, string newPassword)
        {
            return _unitOfWork.AccountRepository.AddPasswordAsync(userId, newPassword);
        }

        /// <summary>
        /// Удалить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        public Task<IdentityResult> RemovePasswordAsync(int userId)
        {
            return _unitOfWork.AccountRepository.RemovePasswordAsync(userId);
        }

        /// <summary>
        /// Удалить логин
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns></returns>
        public Task<IdentityResult> RemoveLoginAsync(int userId, string loginProvider, string providerKey)
        {
            return _unitOfWork.AccountRepository.RemoveLoginAsync(userId, loginProvider, providerKey);
        }

        #endregion

        #region private

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="userModel">Пользователь</param>
        /// <param name="isCheckPassword">true - проверять пароль</param>
        /// <returns></returns>
        private async Task<string> Validation(IApplicationUserModel userModel, bool isCheckPassword)
        {
            if (string.IsNullOrEmpty(userModel.FirstName))
            {
                return ResourceBusinessServices.AccountsController_FirstNameIsNull;
            }

            if (string.IsNullOrEmpty(userModel.LastName))
            {
                return ResourceBusinessServices.AccountsController_LastNameIsNull;
            }

            if (string.IsNullOrEmpty(userModel.UserName))
            {
                return ResourceBusinessServices.AccountsController_UserNameIsNull;
            }

            if (isCheckPassword && string.IsNullOrEmpty(userModel.Password))
            {
                return ResourceBusinessServices.AccountsController_PasswordIsNull;
            }

            if (isCheckPassword && string.IsNullOrEmpty(userModel.ConfirmPassword))
            {
                return ResourceBusinessServices.AccountsController_ConfirmPasswordIsNull;
            }

            if (isCheckPassword && !string.Equals(userModel.Password, userModel.ConfirmPassword))
            {
                return ResourceBusinessServices.AccountsController_PasswordNotEquals;
            }

            if (userModel.Position == null)
            {
                return ResourceBusinessServices.AccountsController_PositionIsNull;
            }

            if (userModel.EmployeeStatus == null)
            {
                return ResourceBusinessServices.AccountsController_EmployeeStatusIsNull;
            }

            var position = await _unitOfWork.PositionRepository.GetByIdAsync(userModel.Position.Id);
            if (position == null)
            {
                return string.Format(ResourceBusinessServices.AccountsController_PositionRepositoryIsNull, userModel.Position.Id);
            }

            var employeeStatus = await _unitOfWork.EmployeeStatusRepository.GetByIdAsync(userModel.EmployeeStatus.Id);
            if (employeeStatus == null)
            {
                return string.Format(ResourceBusinessServices.AccountsController_EmployeeStatusRepositoryIsNull, userModel.EmployeeStatus.Id);
            }

            return string.Empty;
        }

        #endregion

        #region IDisposable

        /// <summary>  
        /// Dispose  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>  
        /// IDisposable
        /// </summary>  
        /// <param name="disposing"></param>  
        protected void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _unitOfWork.Dispose();
            }
            this._disposed = true;
        }

        #endregion
    }
}
