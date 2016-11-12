using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessEntities.Editable.Interfaces
{
    public interface IMonthObjectiveModel : IBaseBusninessModel
    {
        /// <summary>
        /// Платформа
        /// </summary>
        IPlatformModel Platform
        {
            get;
            set;
        }

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

        /// <summary>
        /// Цель - количество чеков на повара-сушиста в час
        /// </summary>
        float ChecksPerHourForPositionSushiChef
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на курьера в час
        /// </summary>
        float ChecksPerHourForPositionCourier
        {
            get;
            set;
        }

        /// <summary>
        /// Цель - количество чеков на повара-пиццера в час
        /// </summary>
        float ChecksPerHourForPositionPizzaChef
        {
            get;
            set;
        }
    }
}
