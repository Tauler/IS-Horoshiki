using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    public interface IShiftPersonalShiftTimeModel
    {
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
