using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для графика смен персонала
    /// </summary>
    public enum ShiftPersonalScheduleErrors
    {
        /// <summary>
        /// Указаны смены с разными датами!
        /// </summary>
        CollectionDateMoreOne,

        /// <summary>
        /// Указаны смены с разными сотрудниками!
        /// </summary>
        CollectionUserMoreOne,

        /// <summary>
        /// Указана смена усиление с другими типами смен!
        /// </summary>
        ShiftTypeIntensificationWithAnyTypes,

        /// <summary>
        /// Для существующего графика смены указана дата, отличная от сохраненной даты в БД!
        /// </summary>
        UpdateMistakeDate,

        /// <summary>
        /// Для существующего графика смены указан тип смены, отличный от типа сохраненного в БД!
        /// </summary>
        UpdateMistakeType,

        /// <summary>
        /// Для существующего графика смены указан сотрудник, отличный от типа сохраненного в БД!
        /// </summary>
        UpdateMistakeUser,

        /// <summary>
        /// Тип смены с указанным Id="{0}" не существует!
        /// </summary>
        ShiftTypeNotFound,

        /// <summary>
        /// Сотрудника с указанным Id="{0}" не существует!
        /// </summary>
        UserNotFound,

        /// <summary>
        /// Не указан тип смены!
        /// </summary>
        ShiftTypeIsNull,

        /// <summary>
        /// Не указан сотрудник!
        /// </summary>
        UserIsNull,
    }
}
