using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Linq;

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
    }
}
