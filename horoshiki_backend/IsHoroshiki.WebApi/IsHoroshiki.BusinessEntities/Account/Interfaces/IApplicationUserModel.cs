using System;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Account.Interfaces
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public interface IApplicationUserModel : IApplicationUserSmallModel
    {
        /// <summary>
        /// Отчество
        /// </summary>
        string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Телефон
        /// </summary>
        string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// Наличие мед книжки
        /// </summary>
        bool IsHaveMedicalBook
        {
            get;
            set;
        }

        /// <summary>
        /// Наличие мед книжки
        /// </summary>
        DateTime? MedicalBookEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Статус сотрудника
        /// </summary>
        IEmployeeStatusModel EmployeeStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Причины увольнения сотрудника
        /// </summary>
        IEmployeeReasonDismissalModel EmployeeReasonDismissal
        {
            get;
            set;
        }

        /// <summary>
        /// Должности
        /// </summary>
        IPositionModel Position
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        IPlatformModel Platform
        {
            get;
            set;
        }
        
        /// <summary>
        /// Отдел
        /// </summary>
        IDepartmentModel Department
        {
            get;
            set;
        }

        /// <summary>
        /// Дата приема
        /// </summary>
        DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата уволнениея
        /// </summary>
        DateTime? DateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Доступ в систему
        /// </summary>
        bool IsAccess
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// </summary>
        string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Пароль
        /// </summary>
        string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Потдверждение пароля
        /// </summary>
        string ConfirmPassword
        {
            get;
            set;
        }
    }
}
