using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.BusinessEntities.Account
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