using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    /// <summary>
    /// Настройки смены для должностей
    /// </summary>
    public interface IShiftPersonalTableModel
    {
        /// <summary>
        /// Настройки смены для должностей
        /// </summary>
        List<IShiftPersonalDataRowModel> DataRows
        {
            get;
            set;
        }
    }
}
