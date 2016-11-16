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
    public class ShiftPersonalDataRowModel : IShiftPersonalDataRowModel
    {
        /// <summary>
        /// Название должности
        /// </summary>
        public string Position
        {
            get;
            set;
        }

        /// <summary>
        /// Настройки смен для должности
        /// </summary>
        public List<IShiftPersonalShiftTimeModel> ShiftTime
        {
            get;
            set;
        }
    }
}
