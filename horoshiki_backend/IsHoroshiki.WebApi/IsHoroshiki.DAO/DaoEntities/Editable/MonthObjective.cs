using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Цель на месяц по показателям
    /// </summary>
    public class MonthObjective : BaseDaoEntity
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
        /// Цель - количество чеков на повара-сушиста в час
        /// </summary>
        public double ChecksPerHourForPositionSushiChef
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на курьера в час
        /// </summary>
        public double ChecksPerHourForPositionCourier
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на повара-пиццера в час
        /// </summary>
        public double ChecksPerHourForPositionPizzaChef
        {
            get;
            set;
        }
    }
}
