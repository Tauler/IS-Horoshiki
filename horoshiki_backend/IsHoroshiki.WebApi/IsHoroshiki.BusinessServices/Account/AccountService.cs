using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Account.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Account
{
    /// <summary>
    /// Сервис аккаунтов
    /// </summary>
    public class AccountService : BaseBusinessService, IAccountService
    {
        #region поля и свойства

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
        /// <param name="unitOfWork">UnitOfWork</param>
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
            return new PagedResult<IApplicationUserModel>(list.ToModelEntityList(), pageNo, pageSize, count);
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
                return user.ToModelEntity();
            }

            return null;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public Task<IdentityResult> RegisterAsync(IApplicationUserModel userModel)
        {
            return _unitOfWork.AccountRepository.RegisterAsync(userModel.ToDaoEntity(), userModel.Password);
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

        #region IDisposable

        /// <summary>  
        /// IDisposable
        /// </summary>  
        /// <param name="disposing"></param>  
        protected override void Dispose(bool disposing)
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
