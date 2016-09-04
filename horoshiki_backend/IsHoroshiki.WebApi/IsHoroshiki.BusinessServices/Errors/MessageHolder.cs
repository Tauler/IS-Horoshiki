using System;

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
            this.SetValue(GetCode(code), message);
        }

        /// <summary>
        /// Возвращает сообщение сервиса
        /// </summary>
        /// <param name="code">Код сообщения</param>
        /// <param name="parameters">Параметры сообщения</param>
        /// <returns>Сообщение сервиса</returns>
        public string GetMessage(Enum code, object[] parameters = null)
        {
            var keyCode = GetCode(code);
            var messageFormat = this.GetValue(keyCode);
            return parameters == null ? messageFormat : string.Format(messageFormat, parameters);
        }

        /// <summary>
        /// Сформировать ключ для сообщения
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetCode(Enum code)
        {
            return $"{code.GetType().Name}_{code}";
        }
    }
}
