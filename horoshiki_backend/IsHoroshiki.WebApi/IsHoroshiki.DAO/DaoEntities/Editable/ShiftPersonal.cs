using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Смена работы персонала
    /// </summary>
    public class ShiftPersonal : BaseDaoEntity
    {
        /// <summary>
        /// Должность
        /// </summary>
        public int PositionId
        {
            get;
            set;
        }

        /// <summary>
        /// Должность
        /// </summary>
        public Position Position
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
        /// Тип смены
        /// </summary>
        public ShiftType ShiftType
        {
            get;
            set;
        }

        /// <summary>
        /// true - Круглосуточно
        /// </summary>
        public bool IsAroundClock
        {
            get;
            set;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        public TimeSpan StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Окончание работы
        /// </summary>
        public TimeSpan StopTime
        {
            get;
            set;
        }
    }
}
