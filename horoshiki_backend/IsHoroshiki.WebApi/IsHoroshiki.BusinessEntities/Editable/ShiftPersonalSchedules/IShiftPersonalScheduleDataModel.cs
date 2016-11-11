using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Планированиe графика работы сотрудников на период (фильтр для построения отчета)
    /// </summary>
    public interface IShiftPersonalScheduleDataModel : IBaseBusninessModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Список отделов
        /// </summary>
        ICollection<IDepartmentModel> Departaments
        {
            get;
            set;
        }

        /// <summary>
        /// Список подотделов
        /// </summary>
        ICollection<ISubDepartmentModel> SubDepartaments
        {
            get;
            set;
        }

        /// <summary>
        /// Тип плана
        /// </summary>
        PlanType PlanType
        {
            get;
            set;
        }

        /// <summary>
        /// Дата начала формирования графика расписания 
        /// </summary>
        DateTime DateStart
        {
            get;
            set;
        }

        /// <summary>
        /// Дата окончания формирования графика расписания 
        /// </summary>
        DateTime DateEnd
        {
            get;
            set;
        }
    }
}