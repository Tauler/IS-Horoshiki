using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// ������ ����������� ���������� ������������
    /// </summary>
    public class RegisterExternalBindingModel
    {
        /// <summary>
        /// �����
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}