using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    /// <summary>
    /// Настройки смен для должности
    /// </summary>
    public interface IShiftPersonalDataRowModel
    {
        /// <summary>
        /// Название должности
        /// </summary>
        string Position
        {
            get;
            set;
        }

        /// <summary>
        /// Настройки смен для должности
        /// </summary>
        List<IShiftPersonalShiftTimeModel> ShiftTimes
        {
            get;
            set;
        }
    }
}
