using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using IsHoroshiki.DAO.DaoEntities.Accounts;
using System.Linq;
using IsHoroshiki.DAO.Repositories.Accounts.Interfaces;
using System.Collections.Generic;
using IsHoroshiki.DAO.Helpers;

namespace IsHoroshiki.DAO.Repositories.Accounts
{
    /// <summary>
    /// Репозитарий авторизации
    /// </summary>
    public class AccountRepository : BaseRepository<ApplicationUser>, IAccountRepository
    {
        #region поля и свойства

        /// <summary>
        /// Конфигурация хранилища пользователя
        /// </summary>
        private readonly ApplicationUserManager _userManager;

        #endregion

        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public AccountRepository(ApplicationDbContext context)
            : base(context)
        {
            var userStore = new CustomUserStore(context);
            _userManager = new ApplicationUserManager(userStore);
        }

        #endregion

        #region методы

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
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true, bool isLoadChild = true,
            string filterLastName = "", bool? filterIsAccess = null, int filterEmployeeStatusId = 0, int filterPositionId = 0, int filterDepartmentId = 0,
            int filterPlatformId = 0, bool? filterIsHaveMedicalBook = null)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filterLastName))
            {
                filterLastName = filterLastName.ToUpper();               
                query = query.Where(u => u.LastName.ToUpper().Contains(filterLastName));
            }

            if (filterIsAccess.HasValue)
            {
                query = query.Where(u => u.IsAccess == filterIsAccess.Value);
            }

            if (filterEmployeeStatusId > 0)
            {
                query = query.Where(u => u.EmployeeStatusId == filterEmployeeStatusId);
            }

            if (filterPositionId > 0)
            {
                query = query.Where(u => u.PositionId == filterPositionId);
            }

            if (filterDepartmentId > 0)
            {
                query = query.Where(u => u.DepartmentId == filterDepartmentId);
            }

            if (filterPlatformId > 0)
            {
                query = query.Where(u => u.PlatformId == filterPlatformId);
            }

            if (filterIsHaveMedicalBook.HasValue)
            {
                query = query.Where(u => u.IsHaveMedicalBook == filterIsHaveMedicalBook.Value);
            }

            int skip = (pageNo - 1) * pageSize;

            var list = query.Where(u => u.Position != null && u.Position.Guid != DatabaseConstant.PositionOperationDirector)
                            .OrderByPropertyName(sortField, isAscending)
                            .Skip(skip)
                            .Take(pageSize)
                            .ToList()
                            .AsEnumerable();

            if (isLoadChild)
            {
                foreach (var daoEntity in list)
                {
                    LoadChildEntities(daoEntity);
                }
            }

            return list;
        }

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        /// <returns></returns>
        public override async Task<ApplicationUser> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        /// <summary>
        /// Количество всех пользователей
        /// </summary>
        /// <returns></returns>
        public override async Task<int> CountAsync()
        {
            return _userManager.Users.Count();
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="entity"></param>
        public override void Insert(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="entity">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public Task<IdentityResult> InsertAsync(ApplicationUser entity, string password)
        {
            SetChildEntity(entity);

            return _userManager.CreateAsync(entity, password);
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            user.EmployeeStatus = Context.EmployeeStatuses.Find(user.EmployeeStatusId);
            user.Position = Context.Positions.Find(user.PositionId);
            user.Platform = Context.Platform.Find(user.PlatformId);

            return _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="user">Пользователь</param>
        public Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            return _userManager.DeleteAsync(user);
        }

        /// <summary>
        /// Найти пользоватея
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        /// <summary>
        /// Найти пользоватея
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<IUser<int>> FindAsync(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);
        }

        /// <summary>
        /// Создание Identity пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType">Тип аутентификации</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(IUser<int> user, string authenticationType)
        {
            var applicationUser = _userManager.FindById(user.Id);

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await _userManager.CreateIdentityAsync(applicationUser, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public async Task<IdentityResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public async Task<IdentityResult> ChangePasswordAsync(int userId, string newPassword)
        {
            var removePasswordResult = await _userManager.RemovePasswordAsync(userId);
            if (!removePasswordResult.Succeeded)
            {
                return removePasswordResult;
            }
            return await _userManager.AddPasswordAsync(userId, newPassword);
        }

        /// <summary>
        /// Установить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public async Task<IdentityResult> AddPasswordAsync(int userId, string newPassword)
        {
            return await _userManager.AddPasswordAsync(userId, newPassword);
        }

        /// <summary>
        /// Удалить пароль
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        public async Task<IdentityResult> RemovePasswordAsync(int userId)
        {
            return await _userManager.RemovePasswordAsync(userId);
        }

        /// <summary>
        /// Удалить логин
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RemoveLoginAsync(int userId, string loginProvider, string providerKey)
        {
            return await _userManager.RemoveLoginAsync(userId, new UserLoginInfo(loginProvider, providerKey));
        }

        /// <summary>
        /// true - если существует площадка для пользователя
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <returns></returns>
        public bool IsExistForPlatform(int platformId)
        {
            return DbSet.Any(p => p.PlatformId == platformId);
        }

        /// <summary>
        /// Получить всех управляющих
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllSmallManager(string sortField = "", bool isAscending = true)
        {
            var list = DbSet.Where(u => u.EmployeeStatus != null
                                        && u.EmployeeStatus.Guid != DatabaseConstant.EmployeeStatusDismissal 
                                        && u.Position != null 
                                        && u.Position.Guid == DatabaseConstant.PositionManager)
                           .OrderByPropertyName(sortField, isAscending)                        
                           .ToList()
                           .AsEnumerable();

            foreach (var daoEntity in list)
            {
                LoadChildEntities(daoEntity);
            }

            return list;
        }

        /// <summary>
        /// Получить всех стажеров
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAllSmallTrainee(string sortField = "", bool isAscending = true)
        {
            var list = DbSet.Where(u => u.EmployeeStatus != null && u.EmployeeStatus.Guid == DatabaseConstant.EmployeeStatusTrainee)
                           .OrderByPropertyName(sortField, isAscending)
                           .ToList()
                           .AsEnumerable();

            foreach (var daoEntity in list)
            {
                LoadChildEntities(daoEntity);
            }

            return list;
        }

        #endregion

        #region override

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void BeforeInsert(ApplicationUser entity)
        {
            SetChildEntity(entity);
        }

        /// <summary>
        /// Действие с сущностью перед обновлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void BeforeUpdate(ApplicationUser entity)
        {
            SetChildEntity(entity);
        }

        /// <summary>
        /// Действие с сущностью перед обновлением в БД
        /// </summary>
        /// <param name="entity"></param>
        private void SetChildEntity(ApplicationUser entity)
        {
            if (entity.PlatformId.HasValue && entity.PlatformId.Value > 0)
            {
                entity.Platform = Context.Platform.Find(entity.PlatformId);
            }
           
            entity.EmployeeStatus = Context.EmployeeStatuses.Find(entity.EmployeeStatusId);
            entity.Position = Context.Positions.Find(entity.PositionId);

            if (entity.DepartmentId.HasValue && entity.DepartmentId.Value > 0)
            {
                entity.Department = Context.Departments.Find(entity.DepartmentId);
            }

            if (entity.EmployeeReasonDismissalId.HasValue && entity.EmployeeReasonDismissalId.Value > 0)
            {
                entity.EmployeeReasonDismissal = Context.EmployeeReasonDismissals.Find(entity.EmployeeReasonDismissalId);
            }
        }

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void LoadChildEntities(ApplicationUser entity)
        {
            if (entity == null)
            {
                return;
            }

            Context.Entry(entity).Reference(p => p.EmployeeStatus).Load();
            Context.Entry(entity).Reference(p => p.Position).Load();
            Context.Entry(entity).Reference(p => p.Platform).Load();
            Context.Entry(entity).Reference(p => p.Department).Load();
            Context.Entry(entity).Reference(p => p.EmployeeReasonDismissal).Load();
        }

        #endregion
    }
}
