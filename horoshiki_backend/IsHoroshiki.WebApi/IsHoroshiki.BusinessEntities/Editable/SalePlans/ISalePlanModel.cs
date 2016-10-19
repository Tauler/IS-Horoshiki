using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlan
{
    /// <summary>
    /// План продаж
    /// </summary>
    public interface ISalePlanModel : IBaseBusninessModel
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        SubDivisionModel SubDivision
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Период планирования
        /// </summary>
        ISalePlanPeriodModel SalePlanPeriod
        {
            get;
            set;
        }

        /// <summary>
        /// Период для анализа 1
        /// </summary>
        ISalePlanPeriodModel AnalizePeriod1
        {
            get;
            set;
        }

        /// <summary>
        /// Период для анализа 2
        /// </summary>
        ISalePlanPeriodModel AnalizePeriod2
        {
            get;
            set;
        }

        /// <summary>
        /// Планируемый средний чек
        /// </summary>
        float AvarageCheck
        {
            get;
            set;
        }

        /// <summary>
        /// Тип плана
        /// </summary>
        PlanType PlanType
        {
            get;
            set;
        }
    }
}