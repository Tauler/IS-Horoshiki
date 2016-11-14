using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.NotEditable.Interfaces
{
    /// <summary>
    /// Репозиторий Должности
    /// </summary>
    public interface IPositionRepository : IBaseNotEditableDictionaryRepository<Position>
    {
        /// <summary>
        /// Получить список всех должностей кроме:
        /// 1) Операционного директора;
        /// 2) Управляющего рестораном;
        /// 3) Курьера
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Position>> GetPositionsOnShiftAsync();
    }
}
