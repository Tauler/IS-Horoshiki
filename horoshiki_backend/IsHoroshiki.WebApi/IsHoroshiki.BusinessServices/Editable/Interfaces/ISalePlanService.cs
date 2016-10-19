using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.Interfaces
{
    /// <summary>
    /// Сервис План продаж
    /// </summary>
    public interface ISalePlanService : IBaseEditableService<ISalePlanModel>
    {
        /// <summary>
        /// Создать план
        /// </summary>
        Task<SalePlanTableModel> CreatePlan(ISalePlanModel model);
    }
}
