using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий День плана продаж
    /// </summary>
    public class SalePlanDayRepository : BaseRepository<SalePlanDay>, ISalePlanDayRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SalePlanDayRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region ISalePlanDayRepository

        /// <summary>
        /// Найти дни по плану
        /// </summary>
        /// <param name="salePlanId">Id плана продаж</param>
        /// <returns></returns>
        public List<SalePlanDay> GetBySalePlan(int salePlanId)
        {
            return DbSet.Where(spd => spd.SalePlanId == salePlanId).ToList();
        }

        /// <summary>
        /// Кол-во чеков из плана продаж за период
        /// </summary>
        /// <param name="platformId">Площадка</param>
        /// <param name="planTypeId">Id тип плана</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateEnd">Дата окончания</param>
        /// <returns></returns>
        public Dictionary<DateTime, int> GetByCountPeriod(int platformId, int planTypeId, DateTime dateStart, DateTime dateEnd)
        {
            var result = DbSet.Where(spd => spd.SalePlan != null
                                                && spd.SalePlan.PlatformId == platformId
                                                && spd.SalePlan.PlanTypeId == planTypeId
                                                && spd.Date >= dateStart
                                                && spd.Date <= dateEnd
                                    ).GroupBy(spd => spd.Date)
                                     .ToDictionary(spd => spd.Key, spd => spd.Sum(d => d.Delivery + d.Self));

            return result;
        }

        #endregion
    }
}
