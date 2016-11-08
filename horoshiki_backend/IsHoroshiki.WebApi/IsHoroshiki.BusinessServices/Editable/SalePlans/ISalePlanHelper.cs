using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports;

namespace IsHoroshiki.BusinessServices.Editable.SalePlans
{
    /// <summary>
    /// Создать план, если не существует на указанный период.
    /// Если существует подтягиваем данные из БД.
    /// </summary>
    public interface ISalePlanHelper
    {
        /// <summary>
        /// Создать план, если не существует на указанный период.
        /// Если существует подтягиваем данные из БД.
        Task<ISalePlanTableModel> Get(ISalePlanModel model);

        /// <summary>
        /// Отчет плана продаж
        /// </summary>
        Task<ISalePlanReportModel> GetReport(ISalePlanModel model);
    }
}