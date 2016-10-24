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
        /// Создать\Редактировать план
        /// </summary>
        Task<SalePlanTableModel> Add(ISalePlanModel model);

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        Task<SalePlanTableModel> Update(ISalePlanModel model);

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        Task<ModelEntityModifyResult> UpdateAverageCheck(ISalePlanModel model);

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        Task<ModelEntityModifyResult> UpdateCell(ISalePlanCellModel model);
    }
}
