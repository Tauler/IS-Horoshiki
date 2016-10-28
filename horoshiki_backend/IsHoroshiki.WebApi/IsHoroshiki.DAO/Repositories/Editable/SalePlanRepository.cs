using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий План продаж
    /// </summary>
    public class SalePlanRepository : BaseRepository<SalePlan>, ISalePlanRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SalePlanRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region ISalePlanRepository

        /// <summary>
        /// Найти план по периоду
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        public SalePlan GetByPeriod(int platformId, int planTypeId, int year, int month)
        {
            return DbSet.FirstOrDefault(plan => plan.PlatformId == platformId 
                && plan.PlanTypeId == planTypeId
                && plan.Year == year 
                && plan.Month == month);
        }

        /// <summary>
        /// Есть ли план продаж на этот период
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        public bool IsExist(int platformId, int planTypeId, int year, int month)
        {
            return DbSet.Any(plan => plan.PlatformId == platformId
                && plan.PlanTypeId == planTypeId
                && plan.Year == year
                && plan.Month == month);
        }

        #endregion
    }
}
