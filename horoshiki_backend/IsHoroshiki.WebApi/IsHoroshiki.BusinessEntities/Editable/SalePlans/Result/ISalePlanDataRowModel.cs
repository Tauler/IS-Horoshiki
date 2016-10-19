namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Строка плана
    /// </summary>
    public interface ISalePlanDataRowModel
    {
        /// <summary>
        /// План на месяц (который редактируется)
        /// </summary>
        ISalePlanDayModel Plan
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 1
        /// </summary>
        ISalePlanDayModel Analize1
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 2
        /// </summary>
        ISalePlanDayModel Analize2
        {
            get;
            set;
        }
    }
}