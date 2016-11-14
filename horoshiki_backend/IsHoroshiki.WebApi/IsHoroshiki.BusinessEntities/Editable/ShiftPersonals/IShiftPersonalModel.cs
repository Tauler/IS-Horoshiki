using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    public interface IShiftPersonalModel : IBaseBusninessModel
    {
        /// <summary>
        /// Должность
        /// </summary>
        IPositionModel Position
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        IShiftTypeModel ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Начало смены
        /// </summary>
        TimeSpan TimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// Конец смены
        /// </summary>
        TimeSpan TimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Круглосуточный режим работы
        /// </summary>
        bool IsAroundClock
        {
            get;
            set;
        }
    }
}
