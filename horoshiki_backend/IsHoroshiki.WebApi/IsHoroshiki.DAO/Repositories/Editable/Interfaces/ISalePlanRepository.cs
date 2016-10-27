using IsHoroshiki.DAO.DaoEntities.Editable;

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
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        SalePlan GetByPeriod(int platformId, int planTypeId, int year, int month);

        /// <summary>
        /// Есть ли план продаж на этот период
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        bool IsExist(int platformId, int planTypeId, int year, int month);
    }
}
