using System;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// Информация о пользователу
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// true - зарегистрирован как внешний пользователь
        /// </summary>
        public bool HasRegistered { get; set; }

        /// <summary>
        /// Провайдер
        /// </summary>
        public string LoginProvider { get; set; }
    }
}
