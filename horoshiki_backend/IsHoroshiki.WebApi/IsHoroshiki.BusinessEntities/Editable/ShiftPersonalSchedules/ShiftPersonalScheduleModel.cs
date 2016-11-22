using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Смена сотрудника
    /// </summary>
    public class ShiftPersonalScheduleModel : BaseBusninessModel, IShiftPersonalScheduleModel
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
        /// Тип смены
        [JsonConverter(typeof(EntityModelConverter<ShiftTypeModel, IShiftTypeModel>))]
        /// </summary>
        public IShiftTypeModel ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Дата расписания работы сотрудника
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Расписание работы сотрудника (смены)
        /// </summary>
        [JsonConverter(typeof(CollectionEntityConverter<ShiftPersonalSchedulePeriodModel, IShiftPersonalSchedulePeriodModel>))]
        public ICollection<IShiftPersonalSchedulePeriodModel> ShiftPersonalSchedulePeriods
        {
            get;
            set;
        }
    }
}