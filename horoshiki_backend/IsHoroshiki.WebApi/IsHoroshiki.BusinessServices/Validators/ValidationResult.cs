using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<string> Errors
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
        public ValidationResult(IEnumerable<string> errors = null)
        {
            Errors = errors ?? new List<string>();
            IsSucceeded = (errors == null || !errors.Any());
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="error">Ошибкa</param>
        public ValidationResult(string error)
        {
            var result = new List<string>()
            {
                error
            };
            Errors = result;
            IsSucceeded = !result.Any();
        }

        #endregion
    }
}
