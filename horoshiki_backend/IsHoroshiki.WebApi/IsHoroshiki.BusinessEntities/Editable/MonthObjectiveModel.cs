using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable
{
    public class MonthObjectiveModel : BaseBusninessModel, IMonthObjectiveModel
    {
        /// <summary>
        /// Платформа
        /// </summary>
        public IPlatformModel Platform
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
        public float ChecksPerHourForPositionSushiChef
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на курьера в час
        /// </summary>
        public float ChecksPerHourForPositionCourier
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на повара-пиццера в час
        /// </summary>
        public float ChecksPerHourForPositionPizzaChef
        {
            get;
            set;
        }
    }
}
