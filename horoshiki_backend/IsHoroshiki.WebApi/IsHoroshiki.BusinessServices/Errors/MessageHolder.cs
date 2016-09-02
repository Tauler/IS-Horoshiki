﻿using System;

namespace IsHoroshiki.BusinessServices.Errors
{
    /// <summary>
    /// Сообщения сервисов об ошибке\успехе
    /// </summary>
    public class MessageHolder : GenericSimpleHolder<string, string>
    {
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static readonly MessageHolder Instance = new MessageHolder();

        /// <summary>
        /// Конструктор
        /// </summary>
        private MessageHolder()
            : base(false)
        {

        }

        /// <summary>
        /// Помещает сообщение сервиса в коллекцию
        /// </summary>
        /// <param name="code">Код сообщения</param>
        /// <param name="message">Сообщение</param>
        public void AddMessage(Enum code, string message)
        {
            this.SetValue(GetKey(code), message);
        }

        /// <summary>
        /// Возвращает сообщение сервиса
        /// </summary>
        /// <param name="code">Код сообщения</param>
        /// <returns>Сообщение сервиса</returns>
        public string GetMessage(Enum code)
        {
            return this.GetValue(GetKey(code));
        }

        /// <summary>
        /// Сформировать ключ для сообщения
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string GetKey(Enum code)
        {
            return string.Format("{0}_{1}", code.GetType().Name, code.ToString());
        }
    }
}
