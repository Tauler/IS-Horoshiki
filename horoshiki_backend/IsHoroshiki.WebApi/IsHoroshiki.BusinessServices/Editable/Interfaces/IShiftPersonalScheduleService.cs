using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Сервис Планирования графика работы сотрудников на период
    /// </summary>
    public interface IShiftPersonalScheduleService : IBaseEditableService<IShiftPersonalScheduleModel>
    {
        /// <summary>
        /// Таблица Планирования графика работы сотрудников на период
        /// </summary>
        /// <param name="model"> Планирования графика работы сотрудников на период</param>
        /// <returns></returns>
        Task<IShiftPersonalScheduleReportModel> GetReport(IShiftPersonalScheduleDataModel model);

        /// <summary>
        /// Планирование смен сотрудника на оперделенный день
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ModelEntityModifyResult> UpdateCell(ICollection<IShiftPersonalScheduleModel> models);
    }
}
