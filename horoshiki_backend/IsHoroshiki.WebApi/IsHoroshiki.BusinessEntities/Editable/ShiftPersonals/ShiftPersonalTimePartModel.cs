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
    public class ShiftPersonalTimePartModel : IShiftPersonalTimePartModel
    {
        /// <summary>
        /// Идентификатор записи в БД
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Начало смены
        /// </summary>
        public TimeSpan TimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// Конец смены
        /// </summary>
        public TimeSpan TimeEnd
        {
            get;
            set;
        }
    }
}
