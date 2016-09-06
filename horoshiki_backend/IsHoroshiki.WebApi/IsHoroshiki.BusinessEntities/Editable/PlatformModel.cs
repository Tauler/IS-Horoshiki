using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Платформа
    /// </summary>
    public class PlatformModel : BaseBusninessModel, IPlatformModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Подразделение
        /// </summary>
        public int SubDivisionId
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь
        /// </summary>
        public int AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        public int PlatformStatusId
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        public ICollection<int> BuyProcessesIds
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        public string YandexMap
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        public TimeSpan TimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        public TimeSpan TimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Минимальный чек
        /// </summary>
        public decimal MinCheck
        {
            get;
            set;
        }
    }
}
