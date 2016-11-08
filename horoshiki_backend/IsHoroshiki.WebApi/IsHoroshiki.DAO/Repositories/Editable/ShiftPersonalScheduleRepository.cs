using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
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
    }
}
