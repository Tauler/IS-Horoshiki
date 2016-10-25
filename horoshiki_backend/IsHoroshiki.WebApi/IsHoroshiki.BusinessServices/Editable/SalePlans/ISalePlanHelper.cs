using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;

namespace IsHoroshiki.BusinessServices.Editable.SalePlans
{
    /// <summary>
    /// Создать план, если не существует на указанный период.
    /// Если существует подтягиваем данные из БД.
    public interface ISalePlanHelper
    {
        /// <summary>
        /// Создать план, если не существует на указанный период.
        /// Если существует подтягиваем данные из БД.
        Task<SalePlanTableModel> Get(ISalePlanModel model);
    }
}