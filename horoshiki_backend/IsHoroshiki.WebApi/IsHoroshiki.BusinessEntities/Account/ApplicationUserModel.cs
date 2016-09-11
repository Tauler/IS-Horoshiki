using IsHoroshiki.BusinessEntities.NotEditable;
using System;
using System.ComponentModel.DataAnnotations;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;

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
        public string MiddleName
        {
            get;
            set;
        }

        /// <summary>
        /// Телефон
        /// </summary>
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
        [JsonConverter(typeof(EntityModelConverter<EmployeeStatusModel, IEmployeeStatusModel>))]
        public IEmployeeStatusModel EmployeeStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Должности
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PositionModel, IPositionModel>))]
        public IPositionModel Position
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PlatformModel, IPlatformModel>))]
        public IPlatformModel Platform
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
        /// Пароль
        /// </summary>
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Потдверждение пароля
        /// </summary>
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}
