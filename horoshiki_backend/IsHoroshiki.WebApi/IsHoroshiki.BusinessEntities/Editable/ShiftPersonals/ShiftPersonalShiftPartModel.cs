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
    public class ShiftPersonalShiftPartModel : IShiftPersonalShiftPartModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Сокращенное название
        /// </summary>
        public string ShortName
        {
            get;
            set;
        }
    }
}
