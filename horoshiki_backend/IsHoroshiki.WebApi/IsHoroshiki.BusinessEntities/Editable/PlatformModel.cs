using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.Converters;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(EntityModelConverter<SubDivisionModel, ISubDivisionModel>))]
        public ISubDivisionModel SubDivision
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь - управляющий
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<ApplicationUserModel, IApplicationUserModel>))]
        public IApplicationUserModel User
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        [JsonConverter(typeof(EntityModelConverter<PlatformStatusModel, IPlatformStatusModel>))]
        public IPlatformStatusModel PlatformStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        [JsonConverter(typeof(CollectionEntityConverter<BuyProcessModel, IBuyProcessModel>))]
        public ICollection<IBuyProcessModel> BuyProcesses
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
