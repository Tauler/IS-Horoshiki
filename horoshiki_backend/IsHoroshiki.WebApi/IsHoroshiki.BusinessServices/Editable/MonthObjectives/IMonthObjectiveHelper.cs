using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Editable.MonthObjectives
{
    /// <summary>
    /// Создать цель на месяц, если не существует.
    /// Если существует подтягиваем данные из БД.
    public interface IMonthObjectiveHelper
    {
        /// <summary>
        /// Создать цель на месяц, если не существует.
        /// Если существует подтягиваем данные из БД.
        Task<IMonthObjectiveModel> Get(IMonthObjectiveModel model);
    }
}