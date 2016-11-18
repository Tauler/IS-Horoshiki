using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    /// <summary>
    /// Название смены
    /// </summary>
    public interface IShiftPersonalShiftPartModel
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Сокращенное название
        /// </summary>
        string ShortName
        {
            get;
            set;
        }
    }
}
