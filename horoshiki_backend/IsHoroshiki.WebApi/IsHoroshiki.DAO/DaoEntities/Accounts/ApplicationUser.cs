using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsHoroshiki.DAO.Identities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        /// <summary>
        /// Имя
        /// </summary>
        [MaxLength(256)]
        [Required]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Отчество
        /// </summary>
        [MaxLength(256)]
        public string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(256)]
        [Required]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Телефон
        /// </summary>
        [MaxLength(50)]
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
        /// Статус сотрудника
        /// </summary>
        public virtual EmployeeStatus EmployeeStatus
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
        /// Должности
        /// </summary>
        public virtual Position Position
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
    }
}