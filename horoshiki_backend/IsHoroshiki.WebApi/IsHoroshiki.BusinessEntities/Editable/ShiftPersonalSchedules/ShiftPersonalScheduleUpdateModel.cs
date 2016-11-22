using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Обновление смен для пользователя на дату
    /// </summary>
    public class ShiftPersonalScheduleUpdateModel : IShiftPersonalScheduleUpdateModel
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<ApplicationUserModel, IApplicationUserModel>))]
        public IApplicationUserModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Список смен 
        /// </summary>
        [JsonConverter(typeof(CollectionEntityConverter<ShiftPersonalScheduleModel, IShiftPersonalScheduleModel>))]
        public ICollection<IShiftPersonalScheduleModel> ShiftPersonalSchedules
        {
            get;
            set;
        }
    }
}