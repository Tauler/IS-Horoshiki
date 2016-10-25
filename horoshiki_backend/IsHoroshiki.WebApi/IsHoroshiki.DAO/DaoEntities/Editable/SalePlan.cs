using System.Collections.Generic;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// План продаж
    /// </summary>
    public class SalePlan : BaseDaoEntity
    {
        /// <summary>
        /// Площадка
        /// </summary>
        public int PlatformId
        {
            get;
            set;
        }

        /// <summary>
        /// Площадка
        /// </summary>
        public Platform Platform
        {
            get;
            set;
        }

        /// <summary>
        /// Год
        /// </summary>
        public int Year
        {
            get;
            set;
        }

        /// <summary>
        /// Месяц
        /// </summary>
        public int Month
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
        /// Дни планирования
        /// </summary>
        public ICollection<SalePlanDay> SalePlanDays
        {
            get;
            set;
        }
    }
}
