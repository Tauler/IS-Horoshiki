using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для Смена
    /// </summary>
    public enum ShiftPersonalErrors
    {
        /// <summary>
        /// Необходимо указать должность
        /// </summary>
        PositionIsNull,

        /// <summary>
        /// Необходимо указать тип смены
        /// </summary>
        ShiftTypeIsNull,
    }
}
