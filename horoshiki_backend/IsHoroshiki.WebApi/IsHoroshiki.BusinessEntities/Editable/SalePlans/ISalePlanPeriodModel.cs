namespace IsHoroshiki.BusinessEntities.Editable.SalePlans
{
    /// <summary>
    /// Период плана продаж
    /// </summary>
    public interface ISalePlanPeriodModel
    {
        /// <summary>
        /// Год
        /// </summary>
        int Year
        {
            get;
            set;
        }

        /// <summary>
        /// Месяц
        /// </summary>
        int Month
        {
            get;
            set;
        }
    }
}