using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий График периода смен сотрудника
    /// </summary>
    public class ShiftPersonalScheduleRepository : BaseRepository<ShiftPersonalSchedule>, IShiftPersonalScheduleRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public ShiftPersonalScheduleRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region IShiftPersonalScheduleRepository

        /// <summary>
        /// График расписаний смен работы сотрудников
        /// </summary>
        /// <param name="departaments">Список Id отделов (фильтр)</param>
        /// <param name="subDepartaments">Список Id подотделов (фильтр)</param>
        /// <param name="platformId">Id площадки</param>
        /// <param name="dateBegin">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns></returns>
        public List<ScheduleShiftPersonalResult> GetScheduleShiftPersonal(List<int> departaments, List<int> subDepartaments, int platformId, DateTime dateBegin, DateTime dateEnd)
        {
            return Context.Database.SqlQuery<ScheduleShiftPersonalResult>("exec dbo.ScheduleShiftPersonal @Departaments, @SubDepartaments, @PlatformId, @DateBegin, @DateEnd",
                    GetParameterIdList("Departaments", departaments),
                    GetParameterIdList("SubDepartaments", subDepartaments),
                    GetParameter("PlatformId", platformId),
                    GetParameter("DateBegin", dateBegin),
                    GetParameter("DateEnd", dateEnd))
                .ToList();
        }

        /// <summary>
        /// Найти в БД по типу и дате
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="shiftTypeId">Id типа смены</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public ShiftPersonalSchedule GetByParam(int userId, int shiftTypeId, DateTime date)
        {
            return DbSet.FirstOrDefault(s => s.UserId == userId && s.ShiftTypeId == shiftTypeId && s.Date == date);
        }

        /// <summary>
        /// Найти все для пользвателя на дату
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="date">Дата</param>
        /// <returns></returns>
        public List<ShiftPersonalSchedule> GetByParam(int userId, DateTime date)
        {
            return DbSet.Where(s => s.UserId == userId && s.Date == date).ToList();
        }

        #endregion
    }
}
