using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Результат выполнения ХП ScheduleShiftPersonal
    /// </summary>
    public class ScheduleShiftPersonalResult : BaseDaoEntity
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Отдел
        /// </summary>
        public int DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Подотдел
        /// </summary>
        public int SubDepartmentId
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
        /// Период для графика смен сотрудника
        /// </summary>
        public int ShiftPersonalSchedulePeriodId
        {
            get;
            set;
        }

	/// <summary>
        /// Тип смены сотрудника
        /// </summary>
        public int ShiftTypeId
        {
            get;
            set;
        }
    }
}
