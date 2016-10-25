using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Collections.Generic;
using System.Linq;

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


        #endregion
    }
}
