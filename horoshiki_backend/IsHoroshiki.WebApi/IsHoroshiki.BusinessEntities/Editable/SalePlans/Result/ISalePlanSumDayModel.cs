using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Итоговая сумма чеков
    /// </summary>
    public interface ISalePlanSumDayModel
    {
        /// <summary>
        /// Доставка
        /// </summary>
        int Delivery
        {
            get;
            set;
        }

        /// <summary>
        /// Cамовывоз
        /// </summary>
        int Self
        {
            get;
            set;
        }
    }
}
