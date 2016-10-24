using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlan
{
    /// <summary>
    /// Сохранение ячейки плана продаж
    /// </summary>
    public interface ISalePlanCellModel : IBaseBusninessModel
    {
        /// <summary>
        /// План продаж
        /// </summary>
        ISalePlanModel SalePlanModel
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма чеков на день
        /// </summary>
        ISalePlanDayModel SalePlanDayModel
        {
            get;
            set;
        }
    }
}