using System;
using System.Collections.Generic;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Identities;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Платформа
    /// </summary>
    public class Platform : BaseDaoEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Подразделение
        /// </summary>
        public virtual int SubDivisionId
        {
            get;
            set;
        }

        /// <summary>
        /// Подразделение
        /// </summary>
        public virtual SubDivision SubDivision
        {
            get;
            set;
        }

        /// <summary>
        /// Пользователь - управляющий
        /// </summary>
        public virtual int UserId
        {
            get;
            set;
        }

        /// <summary>
        ///  Пользователь - управляющий
        /// </summary>
        public virtual ApplicationUser User
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        public virtual int PlatformStatusId
        {
            get;
            set;
        }

        /// <summary>
        /// Статус площадки
        /// </summary>
        public virtual PlatformStatus PlatformStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Способы покупки
        /// </summary>
        public virtual ICollection<BuyProcess> BuyProcesses
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        public virtual string YandexMap
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        public virtual string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        public virtual TimeSpan TimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        public virtual TimeSpan TimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Минимальный чек
        /// </summary>
        public virtual decimal MinCheck
        {
            get;
            set;
        }
    }
}
