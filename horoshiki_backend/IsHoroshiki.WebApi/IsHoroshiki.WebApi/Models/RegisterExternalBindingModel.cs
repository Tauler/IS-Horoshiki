using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// Данные регистрации анонимного пользователя
    /// </summary>
    public class RegisterExternalBindingModel
    {
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}