using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.BusinessEntities.Account
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