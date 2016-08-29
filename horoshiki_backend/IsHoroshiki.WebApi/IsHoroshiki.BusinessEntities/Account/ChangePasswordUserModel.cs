using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Изменение пароля у рользователя
    /// </summary>
    public class ChangePasswordUserModel 
    {
        [Required(ErrorMessage = "Необходимо указать имя пользователя!")]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Пароль
        /// </summary>
        [StringLength(100, ErrorMessage = "Пароль {0} должен быть не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Потдверждение пароля
        /// </summary>
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не совпадают!")]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}