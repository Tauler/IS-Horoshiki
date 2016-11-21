using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий План продаж
    /// </summary>
    public interface IShiftPersonalRepository : IBaseRepository<ShiftPersonal>
    {
        /// <summary>
        /// Поличить смену
        /// </summary>
        /// <param name="positionId">Идентификатор должности</param>
        /// <param name="shiftTypeId">Идентификатор типа смены</param>
        /// <param name="isAroundClock">Работа круглосуточно</param>
        /// <returns></returns>
        ShiftPersonal Get(int positionId, int shiftTypeId, bool isAroundClock);
    }
}
