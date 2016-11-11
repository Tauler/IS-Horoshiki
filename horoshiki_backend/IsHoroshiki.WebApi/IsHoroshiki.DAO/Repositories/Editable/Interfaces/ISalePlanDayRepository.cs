using IsHoroshiki.DAO.DaoEntities.Editable;
using System.Collections.Generic;
using System;

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

        /// <summary>
        /// Кол-во чеков из плана продаж за период
        /// </summary>
        /// <param name="platformId">Площадка</param>
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns></returns>
        Dictionary<DateTime, int> GetByCountPeriod(int platformId, int planTypeId, DateTime dateStart, DateTime dateEnd);
    }
}
