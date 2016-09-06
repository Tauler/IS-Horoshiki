using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

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
        ISubDivisionModel SubDivision
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь
        /// </summary>
        IApplicationUserModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        IPlatformStatusModel PlatformStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        ICollection<IBuyProcessModel> BuyProcesses
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
