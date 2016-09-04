using System;
using IsHoroshiki.BusinessServices.Errors.Enums;

namespace IsHoroshiki.BusinessServices.Errors.ErrorDatas
{
    /// <summary>
    /// Ошибка авторизации
    /// </summary>
    public sealed class UnauthorizedErrorData : ErrorData
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public UnauthorizedErrorData()
            : base(CommonErrors.Unauthorized)
        {
           
        }

        #endregion
    }
}
