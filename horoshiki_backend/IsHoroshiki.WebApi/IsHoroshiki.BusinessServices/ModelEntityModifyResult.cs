using System.Collections.Generic;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Результат выполнения вставки\удаления в БД
    /// </summary>
    public class ModelEntityModifyResult
    {
        /// <summary>
        /// true - нет ошибок при добавлении\удалении в БД
        /// </summary>
        public bool IsSucceeded
        {
            get;
            private set;
        }

        /// <summary>
        /// true - нет ошибок при валидации
        /// </summary>
        public bool IsValidationSucceeded
        {
            get;
            private set;
        }

        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get;
            private set;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="validationErrors">Ошибки валидации</param>
        public ModelEntityModifyResult(IEnumerable<string> validationErrors)
        {
            IsSucceeded = false;
            IsValidationSucceeded = true;
            ValidationErrors = validationErrors;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="validationError">Ошибкa валидации</param>
        public ModelEntityModifyResult(string validationError)
        {
            IsSucceeded = false;
            IsValidationSucceeded = true;
            ValidationErrors = new List<string>() {validationError};
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ModelEntityModifyResult()
        {
            IsSucceeded = true;
            ValidationErrors = new List<string>();
        }
    }
}
