using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
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
        public IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Список отделов
        /// </summary>
        [JsonConverter(typeof(CollectionEntityConverter<DepartmentModel, IDepartmentModel>))]
        public ICollection<IDepartmentModel> Departaments
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
        /// Тип плана
        /// </summary>
        public PlanType PlanType
        {
            get;
            set;
        }

        /// <summary>
        /// Дата начала формирования графика расписания 
        /// </summary>
        public DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания формирования графика расписания 
        /// </summary>
        public DateTime DateEnd
        {
            get;
            set;
        }
    }
}