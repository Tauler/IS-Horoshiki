using IsHoroshiki.BusinessEntities.Editable.Interfaces;
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
        /// Отдел
        /// </summary>
        IDepartmentModel Departament
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
        /// true - если необходимо формировать на день
        /// </summary>
        bool IsOnDay
        {
            get;
            set;
        }

        /// <summary>
        /// Дата формирования графика расписания.
        /// Или период, если IsOnDay = false
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }        
    }
}