using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Сервис Цель на месяц
    /// </summary>
    public interface IMonthObjectiveService : IBaseEditableService<IMonthObjectiveModel>
    {
        /// <summary>
        /// Создать цель на месяц
        /// </summary>
        Task<IMonthObjectiveModel> Add(IMonthObjectiveModel model);

        /// <summary>
        /// Редактировать показатели цели на месяц
        /// </summary>
        Task<ModelEntityModifyResult> UpdateChecksPerHourForPosition(IMonthObjectiveModel model);
    }
}
