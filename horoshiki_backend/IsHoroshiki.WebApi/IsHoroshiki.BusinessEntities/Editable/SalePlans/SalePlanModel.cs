using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using Newtonsoft.Json;

namespace IsHoroshiki.BusinessEntities.Editable.SalePlan
{
    /// <summary>
    /// План продаж
    /// </summary>
    public class SalePlanModel : BaseBusninessModel, ISalePlanModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PlatformModel, IPlatformModel>))]
        public IPlatformModel Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Период планирования
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<SalePlanPeriodModel, ISalePlanPeriodModel>))]
        public ISalePlanPeriodModel SalePlanPeriod
        {
            get;
            set;
        }

        /// <summary>
        /// Период для анализа 1
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<SalePlanPeriodModel, ISalePlanPeriodModel>))]
        public ISalePlanPeriodModel AnalizePeriod1
        {
            get;
            set;
        }

        /// <summary>
        /// Период для анализа 2
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<SalePlanPeriodModel, ISalePlanPeriodModel>))]
        public ISalePlanPeriodModel AnalizePeriod2
        {
            get;
            set;
        }

        /// <summary>
        /// Планируемый средний чек
        /// </summary>
        public decimal AverageCheck
        {
            get;
            set;
        }

        /// <summary>
        /// Тип плана
        /// </summary>
        public PlanType PlanType
        {
            get;
            set;
        }
    }
}
