using IsHoroshiki.DAO.DaoEntities.Editable;
using System.Collections.Generic;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий День плана продаж
    /// </summary>
    public interface ISalePlanDayRepository : IBaseRepository<SalePlanDay>
    {
        /// <summary>
        /// Найти дни по плану
        /// </summary>
        /// <param name="salePlanId">Id плана продаж</param>
        /// <returns></returns>
        List<SalePlanDay> GetBySalePlan(int salePlanId);
    }
}
