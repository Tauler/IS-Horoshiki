using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Общие ошибки
    /// </summary>
    public enum CommonErrors
    {
        /// <summary>
        /// Необработаннная ошибка
        /// </summary>
        Exception,

        /// <summary>
        /// Пользователь не авторизован
        /// </summary>
        Unauthorized,

        /// <summary>
        /// Не указан объект для сохранения!
        /// </summary>
        EntityAddIsNull,

        /// <summary>
        /// Не указан объект для обновления!
        /// </summary>
        EntityUpdateIsNull,

        /// <summary>
        /// Объекта с Id={0} не существует!
        /// </summary>
        EntityUpdateNotFound,
    }
}
