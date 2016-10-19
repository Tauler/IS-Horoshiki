namespace IsHoroshiki.BusinessEntities.Editable.SalePlans.Result
{
    /// <summary>
    /// Строка плана
    /// </summary>
    public class SalePlanDataRowModel : ISalePlanDataRowModel
    {
        /// <summary>
        /// План на месяц (который редактируется)
        /// </summary>
        public ISalePlanDayModel Plan
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 1
        /// </summary>
        public ISalePlanDayModel Analize1
        {
            get;
            set;
        }

        /// <summary>
        /// Анализ 2
        /// </summary>
        public ISalePlanDayModel Analize2
        {
            get;
            set;
        }
    }
}
