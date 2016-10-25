﻿using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий План продаж
    /// </summary>
    public interface ISalePlanRepository : IBaseRepository<SalePlan>
    {
        /// <summary>
        /// Найти план по периоду
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        SalePlan GetByPeriod(int platformId, int year, int month);
    }
}
