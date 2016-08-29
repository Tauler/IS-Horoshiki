using System.ComponentModel.DataAnnotations;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// ��������� ������ � ������������
    /// </summary>
    public class ChangePasswordUserModel 
    {
        [Required(ErrorMessage = "���������� ������� ��� ������������!")]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// ������
        /// </summary>
        [StringLength(100, ErrorMessage = "������ {0} ������ ���� �� ����� {2} ��������.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// ������������� ������
        /// </summary>
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "������ � ������������� ������ �� ���������!")]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}