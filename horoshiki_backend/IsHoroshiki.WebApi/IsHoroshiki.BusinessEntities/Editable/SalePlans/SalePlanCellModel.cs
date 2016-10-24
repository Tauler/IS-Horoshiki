using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlan
{
    /// <summary>
    /// Сохранение ячейки плана продаж
    /// </summary>
    public class SalePlanCellModel : BaseBusninessModel, ISalePlanCellModel
    {
        /// <summary>
        /// План продаж
        /// </summary>
        public ISalePlanModel SalePlanModel
        {
            get;
            set;
        }

        /// <summary>
        /// Сумма чеков на день
        /// </summary>
        public ISalePlanDayModel SalePlanDayModel
        {
            get;
            set;
        }
    }
}