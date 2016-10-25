using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System;

namespace IsHoroshiki.DAO.Repositories.NotEditable.Interfaces
{
    /// <summary>
    /// Репозиторий Способы покупки
    /// </summary>
    public interface IBuyProcessRepository : IBaseNotEditableDictionaryRepository<BuyProcess>
    {
        /// <summary>
        /// Поиск по Guid
        /// </summary>
        /// <param name="guid">Guid</param>
        /// <returns></returns>
        BuyProcess GetByGuid(Guid guid);
    }
}
