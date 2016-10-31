using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.WebApi.Handlers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace IsHoroshiki.WebApi.Controllers.Editable
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Accounts")]
    public class AccountsController : BaseEditableController<IApplicationUserModel, IAccountService>
    {
        #region поля и свойства

        /// <summary>
        /// Менеджер аутентификации
        /// </summary>
        private IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Пользователи</param>
        public AccountsController(IAccountService service)
            : base(service)
        {

        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <param name="filterLastName">Фильтр по фамилии</param>
        /// <param name="filterIsAccess">Фильтр Доступ в систему</param>
        /// <param name="filterEmployeeStatusId">Фильтр Статус сотрудника</param>
        /// <param name="filterPositionId">Фильтр Должности</param>
        /// <param name="filterDepartmentId">Фильтр Отдел</param>
        /// <param name="filterPlatformId">Фильтр Площадка</param>
        /// <param name="filterIsHaveMedicalBook">Фильтр Наличие мед книжки</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true,
            string filterLastName = "", bool? filterIsAccess = null, int filterEmployeeStatusId = 0, int filterPositionId = 0, int filterDepartmentId = 0,
            int filterPlatformId = 0, bool? filterIsHaveMedicalBook = null)
        {
            try
            {
                var list = await _service.GetAllAsync(pageNo, pageSize, sortField, isAscending,
                    filterLastName, filterIsAccess, filterEmployeeStatusId, filterPositionId, filterDepartmentId, filterPlatformId, filterIsHaveMedicalBook);
               
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        [Route("GetWithoutFilter")]
        public override async Task<IHttpActionResult> Get(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            try
            {
                var list = await _service.GetAllAsync(pageNo, pageSize, sortField, isAscending);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public override async Task<IHttpActionResult> GetAll(string sortField = "", bool isAscending = true)
        {
            try
            {
                var list = await _service.GetAllSmall(sortField, isAscending);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <returns></returns>
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="model">Данные</param>
        /// <returns></returns>
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _service.ChangePasswordAsync(GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="model">Данные</param>
        /// <returns></returns>
        [Route("ChangePasswordUser")]
        public async Task<IHttpActionResult> ChangePasswordUser(ChangePasswordUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _service.ChangePasswordUserAsync(model.UserId, model.Password, model.ConfirmPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// Установить пароль
        /// </summary>
        /// <param name="model">Данные</param>
        /// <returns></returns>
        // POST api/User/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _service.AddPasswordAsync(GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// Получение текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Current")]
        [ResponseType(typeof(ApplicationUserModel))]
        public async Task<IHttpActionResult> GetCurrent()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var result = await _service.GetCurrent(Int32.Parse(userId));
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        /// <summary>
        /// Проверка существования логина для пользователя
        /// </summary>
        /// <param name="model">Модель проверки существования пользователя</param>
        /// <returns></returns>
        [Route("IsExist")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> IsExistUserName(CheckExistUserName model)
        {
            try
            {
                var result = await _service.IsExistUserName(model.UserName);
                return Ok(result);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }


        /// <summary>
        /// Получить всех управляющих
        /// </summary>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        [Route("allManager")]
        public async Task<IHttpActionResult> GetAllSmallManager(string sortField = "", bool isAscending = true)
        {
            try
            {
                var list = await _service.GetAllSmallManager(sortField, isAscending);
                return Ok(list);
            }
            catch (Exception e)
            {
                return new ErrorMessageResult(e);
            }
        }

        #endregion

        #region методы

        /// <summary>
        /// Найти Id пользователя
        /// </summary>
        /// <returns></returns>
        private int GetUserId()
        {
            return User.Identity.GetUserId<int>();
        }

        /// <summary>
        /// ДОбавление ошибок
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        return new ErrorMessageResult(error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
        
        #endregion
    }
}
