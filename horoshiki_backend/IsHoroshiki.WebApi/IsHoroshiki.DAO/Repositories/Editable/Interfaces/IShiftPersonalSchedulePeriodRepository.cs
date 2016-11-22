using IsHoroshiki.DAO.DaoEntities.Editable;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий Период для графика смен сотрудника
    /// </summary>
    public interface IShiftPersonalSchedulePeriodRepository : IBaseRepository<ShiftPersonalSchedulePeriod>
    {
        /// <summary>
        /// Найти все периоды для смены
        /// </summary>
        /// <param name="scheduleId">Id смены</param>
        /// <returns></returns>
        List<ShiftPersonalSchedulePeriod> GetByShiftPersonalScheduleId(int scheduleId);
    }
}
