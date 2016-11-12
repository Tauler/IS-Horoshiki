using IsHoroshiki.DAO.DaoEntities.Editable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.DAO.Repositories.Editable.Interfaces
{
    /// <summary>
    /// Репозиторий Цели на месяц по показателям
    /// </summary>
    public interface IMonthObjectiveRepository : IBaseRepository<MonthObjective>
    {
        /// <summary>
        /// Найти для данной платформы цели на указанный месяц по показателям
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        MonthObjective Get(int platformId, int year, int month);

        /// <summary>
        /// Существует ли для данной платформы цели на указанный месяц по показателям
        /// </summary>
        /// <param name="platformId">Идентификатор платформы</param>
        /// <param name="year">Год</param>
        /// <param name="month">Месяц</param>
        /// <returns></returns>
        bool IsExist(int platformId, int year, int month);
    }
}
