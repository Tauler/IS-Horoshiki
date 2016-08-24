using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// Изменить пароль пользователя
    /// </summary>
    public class SetPasswordBindingModel
    {
        /// <summary>
        /// Новый пароль
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
