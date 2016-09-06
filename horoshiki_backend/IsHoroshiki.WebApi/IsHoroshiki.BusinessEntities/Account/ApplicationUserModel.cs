using System;
using System.ComponentModel.DataAnnotations;
using IsHoroshiki.BusinessEntities.Account.Interfaces;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class ApplicationUserModel : ApplicationUserSmallModel, IApplicationUserModel
    {
        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(256, ErrorMessage = "Отчество должно быть не более {1} символов.")]
        public string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Телефон
        /// </summary>
        [MaxLength(50, ErrorMessage = "Телефон должен быть не более {1} символов.")]
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Наличие мед книжки
        /// </summary>
        public bool IsHaveMedicalBook
        {
            get;
            set;
        }

        /// <summary>
        /// Наличие мед книжки
        /// </summary>
        public DateTime? MedicalBookEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Статус сотрудника
        /// </summary>
        public int EmployeeStatusId
        {
            get;
            set;
        }

        /// <summary>
        /// Должности
        /// </summary>
        public int PositionId
        {
            get;
            set;
        }

        /// <summary>
        /// Дата приема
        /// </summary>
        public DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата уволнениея
        /// </summary>
        public DateTime? DateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Доступ в систему
        /// </summary>
        public bool IsAccess
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
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
