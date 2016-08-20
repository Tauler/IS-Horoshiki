using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// Удалить пользователя
    /// </summary>
    public class RemoveLoginBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }
}