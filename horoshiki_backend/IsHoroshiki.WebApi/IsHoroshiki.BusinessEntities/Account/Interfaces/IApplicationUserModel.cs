using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using System;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public interface IApplicationUserModel
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Имя
        /// </summary>
        string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Отчество
        /// </summary>
        string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        string LastName
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
        EmployeeStatusModel EmployeeStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Должности
        /// </summary>
        PositionModel Position
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
        /// Логин
        /// </summary>
        string UserName
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
