using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Результат выполнения вставки\удаления в БД
    /// </summary>
    public class ModelEntityModifyResult
    {
        #region поля и свойства

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
        public IEnumerable<ErrorData> ValidationErrors
        {
            get;
            private set;
        }

        /// <summary>
        /// Новый Id при сохранении объекта
        /// </summary>
        public int NewId
        {
            get;
            private set;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="validationErrors">Ошибки валидации</param>
        public ModelEntityModifyResult(IEnumerable<ErrorData> validationErrors)
        {
            IsSucceeded = false;
            IsValidationSucceeded = true;
            ValidationErrors = validationErrors;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="validationError">Ошибкa валидации</param>
        public ModelEntityModifyResult(ErrorData validationError)
        {
            IsSucceeded = false;
            IsValidationSucceeded = true;
            ValidationErrors = new List<ErrorData>() { validationError };
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="code">Код ошибки</param>
        public ModelEntityModifyResult(Enum code)
        {
            IsSucceeded = false;
            IsValidationSucceeded = true;
            ValidationErrors = new List<ErrorData>() { new ErrorData(code) };
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ModelEntityModifyResult()
        {
            IsSucceeded = true;
            IsValidationSucceeded = true;
            ValidationErrors = new List<ErrorData>();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ModelEntityModifyResult(int newId)
            : this()
        {
            NewId = newId;
        }

        #endregion
    }
}
