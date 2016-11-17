using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    public interface IShiftPersonalShiftTimeModel
    {
        bool IsAroundClock
        {
            get;
            set;
        }

        IShiftPersonalShiftPartModel ShiftPart
        {
            get;
            set;
        }

        IShiftPersonalTimePartModel TimePart
        {
            get;
            set;
        }
    }
}
