using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Данные регистрации пользователя
    /// </summary>
    public class RegisterBindingModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Потдверждение пароля
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}