namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Итоговая строка плана
    /// </summary>
    public interface ISalePlanSumRowModel
    {
        /// <summary>
        /// План на месяц (который редактируется)
        /// </summary>
        ISalePlanSumDayModel Plan
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 1
        /// </summary>
        ISalePlanSumDayModel Analize1
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 2
        /// </summary>
        ISalePlanSumDayModel Analize2
        {
            get;
            set;
        }
    }
}