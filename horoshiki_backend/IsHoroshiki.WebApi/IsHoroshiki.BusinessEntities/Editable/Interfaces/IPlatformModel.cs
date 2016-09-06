using System;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessEntities.Editable.Interfaces
{
    /// <summary>
    /// Подразделения
    /// </summary>
    public interface IPlatformModel : IBaseBusninessModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Подразделение
        /// </summary>
        int SubDivisionId
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь
        /// </summary>
        int AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        int PlatformStatusId
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        ICollection<int> BuyProcessesIds
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        string YandexMap
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        TimeSpan TimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        TimeSpan TimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Минимальный чек
        /// </summary>
        decimal MinCheck
        {
            get;
            set;
        }
    }
}
