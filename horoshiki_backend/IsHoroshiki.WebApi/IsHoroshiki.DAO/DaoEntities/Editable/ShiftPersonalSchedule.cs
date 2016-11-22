using IsHoroshiki.DAO.DaoEntities.Accounts;
using System;
using System.Collections.Generic;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// График периода сотрудника на день (смен)
    /// </summary>
    public class ShiftPersonalSchedule : BaseDaoEntity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public ApplicationUser User
        {
            get;
            set;
        }

        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        public ShiftType ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены
        /// </summary>
        public int ShiftTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Дата расписания работы сотрудника
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Периоды работы сотрудника (смены)
        /// </summary>
        public virtual ICollection<ShiftPersonalSchedulePeriod> ShiftPersonalSchedulePeriods
        {
            get;
            set;
        }
    }
}
