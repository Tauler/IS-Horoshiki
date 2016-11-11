using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Построение таблиц графика (расписания) смен сотрудников
    /// </summary>
    public interface IShiftPersonalScheduleHelper
    {
        /// <summary>
        /// График (расписание) смен сотрудников
        /// </summary>
        Task<IShiftPersonalScheduleReportModel> GetReport(IShiftPersonalScheduleDataModel model);
    }
}