using IsHoroshiki.DAO.DaoEntities.Editable;
using System;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий График периода смен сотрудника
    /// </summary>
    public interface IShiftPersonalScheduleRepository : IBaseRepository<ShiftPersonalSchedule>
    {
        /// <summary>
        /// График расписаний смен работы сотрудников
        /// </summary>
        /// <param name="departaments">Список Id отделов (фильтр)</param>
        /// <param name="subDepartaments">Список Id подотделов (фильтр)</param>
        /// <param name="platformId">Id площадки</param>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns></returns>
        List<ScheduleShiftPersonalResult> GetScheduleShiftPersonal(List<int> departaments, List<int> subDepartaments, int platformId, DateTime dateBegin, DateTime dateEnd);

        /// <summary>
        /// Найти в БД по типу и дате
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="shiftTypeId">Id типа смены</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        ShiftPersonalSchedule GetByParam(int userId, int shiftTypeId, DateTime date);

        /// <summary>
        /// Найти все для пользвателя на дату
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        List<ShiftPersonalSchedule> GetByParam(int userId, DateTime date);
    }
}
