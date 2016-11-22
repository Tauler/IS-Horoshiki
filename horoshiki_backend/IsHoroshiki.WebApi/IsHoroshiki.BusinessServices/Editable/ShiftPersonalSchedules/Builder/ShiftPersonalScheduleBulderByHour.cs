using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder
{
    /// <summary>
    /// График расписания по часам
    /// </summary>
    internal class ShiftPersonalScheduleBulderByHour : ShiftPersonalScheduleBulder
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="model">Фильтр для построения отчета</param>
        public ShiftPersonalScheduleBulderByHour(UnitOfWork unitOfWork, IShiftPersonalScheduleDataModel model)
            : base (unitOfWork, model)
        {
            
        }

        #endregion

        #region override
       
        /// <summary>
        /// Подсчет смен для сотрудников
        /// </summary>
        public override void FillUserCellColumns()
        {
            FillSumHourUserRows(_scheduleShiftPersonalResults, _dateStart, _dateEnd, _table);
        }

        #endregion

        #region private

        /// <summary>
        /// Сумма часов работы для сотрудника
        /// </summary>
        /// <param name="scheduleShiftPersonalResults">Результат выполнения ХП</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillSumHourUserRows(List<ScheduleShiftPersonalResult> scheduleShiftPersonalResults, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            foreach (var positionRow in table.PositionScheduleRows)
            {
                foreach (var userRow in positionRow.UserRows)
                {
                    userRow.UserHourColumns = new List<IUserHourColumn>();
                    for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
                    {
                        var userHourColumn = new UserHourColumn()
                        {
                            Date = currentDate
                        };
                        userRow.UserHourColumns.Add(userHourColumn);

                        userHourColumn.SumHour = scheduleShiftPersonalResults.Where(result => result.DateDoc == userHourColumn.Date && result.NormaHour.HasValue)
                            .Sum(result => result.NormaHour.Value);
                    }
                }
            }
        }

        #endregion
    }
}
