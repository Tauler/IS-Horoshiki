namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Итоговая строка плана
    /// </summary>
    public class SalePlanSumRowModel : ISalePlanSumRowModel
    {
        /// <summary>
        /// План на месяц (который редактируется)
        /// </summary>
        public ISalePlanSumDayModel Plan
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 1
        /// </summary>
        public ISalePlanSumDayModel Analize1
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 2
        /// </summary>
        public ISalePlanSumDayModel Analize2
        {
            get;
            set;
        }
    }
}
