using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports;
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
        Task<ISalePlanTableModel> Add(ISalePlanModel model);

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        Task<ISalePlanTableModel> Update(ISalePlanModel model);

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        Task<ModelEntityModifyResult> UpdateAverageCheck(ISalePlanModel model);

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        Task<ModelEntityModifyResult> UpdateCell(ISalePlanDayModel model);

        /// <summary>
        /// Отчет плана продаж
        /// </summary>
        /// <param name="model">План продаж</param>
        /// <returns></returns>
        Task<ISalePlanReportModel> GetReport(ISalePlanModel model);
    }
}
