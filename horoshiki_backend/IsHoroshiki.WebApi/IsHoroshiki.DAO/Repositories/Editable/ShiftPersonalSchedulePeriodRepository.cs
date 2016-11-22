using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Период для графика смен сотрудника
    /// </summary>
    public class ShiftPersonalSchedulePeriodRepository : BaseRepository<ShiftPersonalSchedulePeriod>, IShiftPersonalSchedulePeriodRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public ShiftPersonalSchedulePeriodRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region  IShiftPersonalSchedulePeriodRepository
        
        /// <summary>
        /// Найти все периоды для смены
        /// </summary>
        /// <param name="scheduleId">Id смены</param>
        /// <returns></returns>
        public List<ShiftPersonalSchedulePeriod> GetByShiftPersonalScheduleId(int scheduleId)
        {
            return DbSet.Where(p => p.ShiftPersonalScheduleId == scheduleId).ToList();
        }

        #endregion
    }
}
