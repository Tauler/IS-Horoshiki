using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для платформ
    /// </summary>
    public enum PlatformErrors
    {
        /// <summary>
        /// Необходимо указать наименование!
        /// </summary>
        NameIsNull,

        /// <summary>
        /// Необходимо указать подразделение!
        /// </summary>
        SubDivisionIsNullModel,

        /// <summary>
        /// Необходмио указать способы покупки!
        /// </summary>
        BuyProcessesIsNullModel,

        /// <summary>
        /// Необходимо указать статус площадки!
        /// </summary>
        PlatformStatusIsNullModel,

        /// <summary>
        /// Необходимо указать время начала работы!
        /// </summary>
        TimeStartIsNullModel,

        /// <summary>
        /// Необходимо указать время окончания работы!
        /// </summary>
        TimeEndIsNullModel,

        /// <summary>
        /// Минимальный чек должен быть больше нуля!
        /// </summary>
        MinChecksIsNull,

        /// <summary>
        /// Статуса площадки для указанного ID={0} не существует!
        /// </summary>
        PlatformStatusNotFound,

        /// <summary>
        /// Подразделение для указанного ID={0} не существует!
        /// </summary>
        SubDivisionNotFound,

        /// <summary>
        /// Пользователя для указанного ID={0} не существует!
        /// </summary>
        UserNotFound,

        /// <summary>
        /// Способа покупки для указанного ID={0} не существует!
        /// </summary>
        BuyProcessNotFound,
    }
}
