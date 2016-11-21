using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий  Смена работы персонала
    /// </summary>
    public class ShiftPersonalRepository : BaseRepository<ShiftPersonal>, IShiftPersonalRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public ShiftPersonalRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region IShiftPersonalRepository

        /// <summary>
        /// Поличить смену
        /// </summary>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="shiftTypeId">Идентификатор типа смены</param>
        /// <param name="isAroundClock">Работа круглосуточно</param>
        /// <returns></returns>
        public ShiftPersonal Get(int positionId, int shiftTypeId, bool isAroundClock)
        {
            return DbSet.FirstOrDefault(sp => sp.PositionId == positionId
                && sp.ShiftTypeId == shiftTypeId
                && sp.IsAroundClock == isAroundClock);
        }

        #endregion

        #region protected override

        protected override void LoadChildEntities(ShiftPersonal entity)
        {
            if (entity == null)
            {
                return;
            }
            Context.Entry(entity).Reference(p => p.Position).Load();
            Context.Entry(entity).Reference(p => p.ShiftType).Load();
        }

        #endregion
    }
}
