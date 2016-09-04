using System;

namespace IsHoroshiki.BusinessServices.Errors.ErrorDatas
{
    /// <summary>
    /// Ошибка с описанием
    /// </summary>
    public class ErrorData
    {
        #region поля и свойства

        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code
        {
            get;
            private set;
        }

        /// <summary>
        /// Расшифровка ошибки
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="message">Расшифровка ошибки</param>
        /// <param name="parameters">Параметры сообщения</param>
        public ErrorData(Enum code, string message = "", object[] parameters = null)
        {
            var instance = MessageHolder.Instance;
            Code = instance.GetCode(code);
            Message = !string.IsNullOrEmpty(message) ? message : instance.GetMessage(code, parameters);
        }

        #endregion
    }
}
