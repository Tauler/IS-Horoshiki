using System;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Итоговая сумма чеков
    /// </summary>
    public class SalePlanSumDayModel : ISalePlanSumDayModel
    {
        /// <summary>
        /// Доставка
        /// </summary>
        public int Delivery
        {
            get;
            set;
        }

        /// <summary>
        /// Cамовывоз
        /// </summary>
        public int Self
        {
            get;
            set;
        }
    }
}
