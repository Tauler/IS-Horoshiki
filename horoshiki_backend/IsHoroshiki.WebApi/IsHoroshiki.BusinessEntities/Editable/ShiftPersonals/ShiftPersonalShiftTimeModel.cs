using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    public class ShiftPersonalShiftTimeModel : IShiftPersonalShiftTimeModel
    {
        public bool IsAroundClock
        {
            get;
            set;
        }

        public IShiftPersonalShiftPartModel ShiftPart
        {
            get;
            set;
        }

        public IShiftPersonalTimePartModel TimePart
        {
            get;
            set;
        }
    }
}
