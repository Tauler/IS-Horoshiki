using System;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// Результат выполнения ХП ScheduleShiftPersonal
    /// </summary>
    public class ScheduleShiftPersonalResult
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
        public int? DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Guid Отдел
        /// </summary>
        public Guid? DepartmentGuid
        {
            get;
            set;
        }

        /// <summary>
        /// наименование отдела
        /// </summary>
        public string DepartmentName
        {
            get;
            set;
        }

        /// <summary>
        /// Подотдел
        /// </summary>
        public int? SubDepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Guid Подотдел
        /// </summary>
        public Guid? SubDepartmentGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование подотдела
        /// </summary>
        public string SubDepartmentName
        {
            get;
            set;
        }

        /// <summary>
        /// Пользователь
        /// </summary>
        public int? UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Должность
        /// </summary>
        public int? PositionId
        {
            get;
            set;
        }

        /// <summary>
        /// Guid Должность
        /// </summary>
        public Guid? PositionGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string PositionName
        {
            get;
            set;
        }

        /// <summary>
        /// Период для графика смен сотрудника
        /// </summary>
        public int? ShiftPersonalScheduleId
        {
            get;
            set;
        }

        /// <summary>
        /// Дата для смены
        /// </summary>
        public DateTime? ShiftPersonalScheduleDate
        {
            get;
            set;
        }

        /// <summary>
        /// Тип смены сотрудника
        /// </summary>
        public int? ShiftTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Guid Тип смены сотрудника
        /// </summary>
        public Guid? ShiftTypeGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Описание типа смены
        /// </summary>
        public string ShiftTypeDescr
        {
            get;
            set;
        }

        /// <summary>
        /// Норма часы
        /// </summary>
        public int? NormaHour
        {
            get;
            set;
        }
    }
}
