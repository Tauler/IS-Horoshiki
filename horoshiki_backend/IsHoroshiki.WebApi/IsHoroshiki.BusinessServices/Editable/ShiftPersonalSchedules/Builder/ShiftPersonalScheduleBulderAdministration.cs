using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder
{
    /// <summary>
    /// График расписания для отдела администрация
    /// </summary>
    internal class ShiftPersonalScheduleBulderAdministration : ShiftPersonalScheduleBulderByType
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="model">Фильтр для построения отчета</param>
        public ShiftPersonalScheduleBulderAdministration(UnitOfWork unitOfWork, IShiftPersonalScheduleDataModel model)
            : base (unitOfWork, model)
        {

        }

        #endregion

        #region override

        /// <summary>
        /// Подсчет смен для сотрудников
        /// </summary>
        public override void FillShiftCountColumns()
        {
            FillShiftCountPositionRows(_dateStart, _dateEnd, _table);
        }

        #endregion

        #region private

        /// <summary>
        /// Группировка смен по дням для должности
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillShiftCountPositionRows(DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            foreach (var positionScheduleRow in table.PositionScheduleRows)
            {
                positionScheduleRow.ShiftCountResultColumns = new List<IShiftCountResultColumn>();
                for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
                {
                    var columnResultShiftType = new ShiftCountResultColumn()
                    {
                        Date = currentDate
                    };
                    positionScheduleRow.ShiftCountResultColumns.Add(columnResultShiftType);
                }

                foreach (var shiftCountResultColumn in positionScheduleRow.ShiftCountResultColumns)
                {
                    shiftCountResultColumn.Count = GetUserByShiftTypeCountOnDate(shiftCountResultColumn.Date, positionScheduleRow.UserRows);
                }
            }
        }

        /// <summary>
        /// Сколько сотрудников на смене, подсчитываем по сменам
        /// </summary>
        /// <param name="type">Тип смены</param>
        /// <param name="date">Дата</param>
        /// <param name="userRows">Список сотрудников</param>
        /// <returns></returns>
        private int GetUserByShiftTypeCountOnDate(DateTime date, List<IUserRowModel> userRows)
        {
            return userRows.Sum(userRow => GetUserShiftTypeCountOnDate(date, userRow.UserShiftTypeColumns));
        }

        /// <summary>
        /// Смены для сотрудников на этот день. 
        /// </summary>
        /// <param name="type">Тип смены</param>
        /// <param name="date">Дата</param>
        /// <param name="userShiftTypeColumns">Список смен для сотрудника на дату</param>
        /// <returns></returns>
        private int GetUserShiftTypeCountOnDate(DateTime date, List<IUserShiftTypeColumn> userShiftTypeColumns)
        {
            if (userShiftTypeColumns == null)
            {
                return 0;
            }

            var userShiftTypeColumnOnDate = userShiftTypeColumns.FirstOrDefault(stRow => stRow.Date == date && stRow.Schedules != null);
            if (userShiftTypeColumnOnDate != null && userShiftTypeColumnOnDate.Schedules != null)
            {
                return userShiftTypeColumnOnDate.Schedules.Count();
            }
            return 0;
        }

        #endregion
    }
}
