using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using IsHoroshiki.BusinessServices.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Account;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// 
        /// </summary>
        private const string LocalLoginProvider = "Local";

        /// <summary>
        /// Сервис аккаунтов
        /// </summary>
        private readonly IAccountService _service;

        /// <summary>
        /// Менеджер аутентификации
        /// </summary>
        private IAuthenticationManager Authentication
        {
            get
            {
                return Request.GetOwinContext().Authentication;
            }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Сервис аккаунтов</param>
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        
        #endregion

        #region Сервисы

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
        /// Установить пароль
        /// </summary>
        /// <param name="model">Данные</param>
        /// <returns></returns>
        // POST api/Account/SetPassword
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
        /// Удалить пользователя
        /// </summary>
        /// <param name="model">Данные</param>
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;
            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await _service.RemovePasswordAsync(GetUserId());
            }
            else
            {
                result = await _service.RemoveLoginAsync(GetUserId(), model.LoginProvider, model.ProviderKey);
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="model">Данные</param>
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _service.RegisterAsync(model.UserName, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
  
        #endregion

        #region методы

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
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        /// <summary>
        /// Найти Id пользователя
        /// </summary>
        /// <returns></returns>
        private int GetUserId()
        {
            return User.Identity.GetUserId<int>();
        }

        /// <summary>
        /// Очистить ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && _service != null)
            {
                _service.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region private class 

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static readonly RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
