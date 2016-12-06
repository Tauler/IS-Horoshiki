using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Editable.Helpers;
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

        /// <summary>
        /// Вызов скалярной функции в БД GetScheduleShiftPersonalNormaHour
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        public int GetScheduleShiftPersonalNormaHour(int userId, DateTime dateStart, DateTime dateEnd)
        {
            var result = Context.Database.SqlQuery<int?>("select dbo.GetScheduleShiftPersonalNormaHour(@userId, @shiftTypeId, @dateStart, @dateEnd)",
                           GetParameter("userId", userId),
                           GetParameter("shiftTypeId", 0),
                           GetParameter("dateStart", dateStart),
                           GetParameter("dateEnd", dateEnd)).FirstOrDefault();

            return result.HasValue ? result.Value : 0;
        }

        /// <summary>
        /// Вызов табличной функции с подсчетом планируемых продаж в БД GetSalePlanForScheduleShift
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="departamentId">Id отдела</param>
        /// <param name="subDepartamentId">Id подотдела</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        public List<SalePlanForScheduleShiftResult> GetSalePlanForScheduleShift(int platformId, int departamentId, int subDepartamentId, DateTime dateStart, DateTime dateEnd)
        {
            var result = Context.Database.SqlQuery<SalePlanForScheduleShiftResult>("select * from dbo.GetSalePlanForScheduleShift(@platformId, @departamentId, @subDepartamentId, @dateStart, @dateEnd)",
                           GetParameter("platformId", platformId),
                           GetParameter("departamentId", departamentId),
                           GetParameter("subDepartamentId", subDepartamentId),
                           GetParameter("dateStart", dateStart),
                           GetParameter("dateEnd", dateEnd)).ToList();

            return result != null ? result : new List<SalePlanForScheduleShiftResult>();
        }

        #endregion
    }
}
