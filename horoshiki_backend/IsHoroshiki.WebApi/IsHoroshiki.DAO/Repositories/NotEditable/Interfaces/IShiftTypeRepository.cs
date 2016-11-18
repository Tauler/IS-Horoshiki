using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.Repositories.NotEditable.Interfaces
{
    /// <summary>
    /// Репозиторий Тип смены
    /// </summary>
    public interface IShiftTypeRepository : IBaseNotEditableDictionaryRepository<ShiftType>
    {
        /// <summary>
        /// Получить тип смены - усиление
        /// </summary>
        /// <returns></returns>
        ShiftType GetIntensification();
    }
}
