using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Планированиe графика работы сотрудников на период (фильтр для построения отчета)
    /// </summary>
    public class ShiftPersonalScheduleDataModel : BaseBusninessModel, IShiftPersonalScheduleDataModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PlatformModel, IPlatformModel>))]
        public IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Список отделов
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<DepartmentModel, IDepartmentModel>))]
        public IDepartmentModel Departament
        {
            get;
            set;
        }

        /// <summary>
        /// Список подотделов
        /// </summary>
        [JsonConverter(typeof(CollectionEntityConverter<SubDepartmentModel, ISubDepartmentModel>))]
        public ICollection<ISubDepartmentModel> SubDepartaments
        {
            get;
            set;
        }

        /// <summary>
        /// true - если необходимо формировать на день
        /// </summary>
        public bool IsOnDay
        {
            get;
            set;
        }

        /// <summary>
        /// Дата формирования графика расписания.
        /// Или период, если IsOnDay = false
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }
    }
}