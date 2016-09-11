using System;
using System.Collections.Generic;
using System.Linq;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;

namespace IsHoroshiki.BusinessServices.Validators
{
    /// <summary>
    /// Результат валидации
    /// </summary>
    public class ValidationResult
    {
        #region поля и свойства

        /// <summary>
        /// Валидация успешно пройдена
        /// </summary>
        public bool IsSucceeded
        {
            get;
            set;
        }

        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public IEnumerable<ErrorData> Errors
        {
            get;
            private set;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="errors">Ошибки</param>
        public ValidationResult(IEnumerable<ErrorData> errors = null)
        {
            Errors = errors ?? new List<ErrorData>();
            IsSucceeded = (errors == null || !errors.Any());
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="message">Расшифровка ошибки</param>
        /// <param name="parameters">Параметры сообщения</param>
        public ValidationResult(Enum code, string message = "", object[] parameters = null)
        {
            var result = new List<ErrorData>()
            {
                new ErrorData(code, message, parameters)
            };
            Errors = result;
            IsSucceeded = !result.Any();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код ошибки</param>
        /// <param name="parameters">Параметры сообщения</param>
        public ValidationResult(Enum code, int parameters)
        {
            var result = new List<ErrorData>()
            {
                new ErrorData(code, string.Empty, new object[] { parameters })
            };
            Errors = result;
            IsSucceeded = !result.Any();
        }

        #endregion
    }
}
