using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonals
{
    /// <summary>
    /// Создает результатирующую таблицу с настройками смен работы
    /// </summary>
    public interface IShiftPersonalHelper
    {
        /// <summary>
        /// Создать результатирующую таблицу с настройками смен работы
        /// </summary>
        /// <returns></returns>
        IShiftPersonalTableModel CreateDefaultTable();
    }
}
