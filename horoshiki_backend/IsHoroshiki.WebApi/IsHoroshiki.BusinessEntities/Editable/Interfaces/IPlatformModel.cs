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
        ISubDivisionModel SubDivisionModel
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь - управляющий
        /// </summary>
        IApplicationUserModel UserModel
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        IPlatformStatusModel PlatformStatusModel
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        ICollection<IBuyProcessModel> BuyProcessesModel
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
