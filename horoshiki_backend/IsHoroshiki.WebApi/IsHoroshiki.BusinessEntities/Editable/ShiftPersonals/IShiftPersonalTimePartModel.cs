using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    /// <summary>
    /// Начало и конец работы смены. Изменяемая часть настройки
    /// </summary>
    public interface IShiftPersonalTimePartModel
    {
        /// <summary>
        /// Идентификатор записи в БД
        /// </summary>
        int Id
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
    }
}
