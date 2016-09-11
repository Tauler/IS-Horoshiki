using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок подразделений
    /// </summary>
    public enum SubDivisionErrors
    {
        /// <summary>
        /// Необходимо указать наименование!
        /// </summary>
        NameIsNull,

        /// <summary>
        /// Необходимо указать часовой пояс!
        /// </summary>
        TimezoneIsNull,

        /// <summary>
        /// Некорректное значение часового пояса! Допустимый диапазон от -12 до +12!
        /// </summary>
        TimezoneInvalidPeriod,

        /// <summary>
        /// Необходимо указать тип цены!
        /// </summary>
        PriceTypeIsNullModel,

        /// <summary>
        /// Не найден тип цены с Id={0}!
        /// </summary>
        PriceTypeNotFound,

        /// <summary>
        /// Невозможно удалить подразделение, т.к. оно прикреплено к площадке!
        /// </summary>
        CanNotDeleteExistPlatform
    }
}
