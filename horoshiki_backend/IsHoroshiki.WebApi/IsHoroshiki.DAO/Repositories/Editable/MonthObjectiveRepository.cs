using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Цели на месяц по показателям
    /// </summary>
    public class MonthObjectiveRepository : BaseRepository<MonthObjective>, IMonthObjectiveRepository
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст выполнения БД</param>
        public MonthObjectiveRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region IMonthObjectiveRepository

        /// <summary>
        /// Найти для данной платформы цели на указанный месяц по показателям
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        public MonthObjective Get(int platformId, int year, int month)
        {
            return DbSet.FirstOrDefault(mo => mo.PlatformId == platformId
                && mo.Year == year
                && mo.Month == month);
        }

        /// <summary>
        /// Существует ли для данной платформы цели на указанный месяц по показателям
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        public bool IsExist(int platformId, int year, int month)
        {
            return DbSet.Any(mo => mo.PlatformId == platformId
                && mo.Year == year
                && mo.Month == month);
        }

        #endregion

        #region override

        protected override void LoadChildEntities(MonthObjective entity)
        {
            if (entity == null)
            {
                return;
            }
            Context.Entry(entity).Reference(p => p.Platform).Load();
        }

        #endregion
    }
}
