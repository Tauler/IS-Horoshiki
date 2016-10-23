using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий Чек продаж
    /// </summary>
    public interface ISaleCheckRepository : IBaseRepository<SaleCheck>
    {
        /// <summary>
        /// Найти чек по его Id
        /// </summary>
        /// <param name="idCheck">Id чека</param>
        /// <returns></returns>
        SaleCheck GetByCheckId(string idCheck);
    }
}
