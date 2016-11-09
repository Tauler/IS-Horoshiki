using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonals
{
    public class ShiftPersonalModel : BaseBusninessModel, IShiftPersonalModel
    {
        /// <summary>
        /// Должность
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PositionModel, IPositionModel>))]
        public IPositionModel Position
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<ShiftTypeModel, IShiftTypeModel>))]
        public IShiftTypeModel ShiftType
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

        /// <summary>
        /// Круглосуточный режим работы
        /// </summary>
        public bool IsAroundClock
        {
            get;
            set;
        }
    }
}
