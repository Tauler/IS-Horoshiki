using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder
{
    /// <summary>
    /// График расписания по сменам
    /// </summary>
    internal class ShiftPersonalScheduleBulderByType : ShiftPersonalScheduleBulder
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="model">Фильтр для построения отчета</param>
        public ShiftPersonalScheduleBulderByType(UnitOfWork unitOfWork, IShiftPersonalScheduleDataModel model)
            : base (unitOfWork, model)
        {

        }

        #endregion

        #region override

        /// <summary>
        /// Заполнение ячеек в таблице (смены или часы)
        /// </summary>
        public override void FillUserCellColumns()
        {
            foreach (var scheduleResult in _scheduleShiftPersonalResults)
            {
                if (!scheduleResult.PositionId.HasValue && _table.PositionScheduleRows != null)
                {
                    continue;
                }

                var positionRow = _table.PositionScheduleRows.FirstOrDefault(p => p.Position.Id == scheduleResult.PositionId.Value);
                if (scheduleResult.UserId.HasValue && positionRow != null && positionRow.UserRows != null)
                {
                    var userRow = positionRow.UserRows.FirstOrDefault(ur => ur.User.Id == scheduleResult.UserId.Value);
                    if (userRow != null)
                    {
                        AddScheduleColumns(scheduleResult, userRow);
                    }
                }
            }
        }

        /// <summary>
        /// Подсчет смен для сотрудников
        /// </summary>
        public override void FillShiftCountColumns()
        {
            _table.ShiftCountRow = GetEmptyShiftCountRow(_dateStart, _dateEnd);
            FillShiftCountRows(_dateStart, _dateEnd, _table);
        }

        #endregion

        #region private

        /// <summary>
        /// Создание пустых столбцов для кол-ва чеков на этот день
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        private IShiftCountRow GetEmptyShiftCountRow(DateTime dateStart, DateTime dateEnd)
        {
            var result = new ShiftCountRow();
            result.ShiftCountByTypeRows = new List<IShiftCountByTypeRow>();
            result.ShiftCountResultColumn = new List<IShiftCountResultColumn>();

            var allTypes = _unitOfWork.ShiftTypeRepository.GetAll();

            foreach (var type in allTypes)
            {
                var shiftCountByTypeRow = new ShiftCountByTypeRow()
                {
                    ShiftCountByTypeColumns = new List<IShiftCountByTypeColumn>(),
                    ShiftType = type.ToModelEntity()
                };

                for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
                {
                    var shiftCountByTypeColumn = new ShiftCountByTypeColumn()
                    {
                        Date = currentDate
                    };
                    shiftCountByTypeRow.ShiftCountByTypeColumns.Add(shiftCountByTypeColumn);
                }

                result.ShiftCountByTypeRows.Add(shiftCountByTypeRow);
            }

            for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
            {
                var columnResultShiftType = new ShiftCountResultColumn()
                {
                    Date = currentDate
                };
                result.ShiftCountResultColumn.Add(columnResultShiftType);
            }

            return result;
        }

        /// <summary>
        /// Группировка смен по дням
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillShiftCountRows(DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            table.ShiftCountRow = GetEmptyShiftCountRow(dateStart, dateEnd);

            foreach (var shiftCountRow in table.ShiftCountRow.ShiftCountByTypeRows)
            {
                foreach (var shiftCountByTypeColumn in shiftCountRow.ShiftCountByTypeColumns)
                {
                    shiftCountByTypeColumn.Count = table.PositionScheduleRows.Sum(positionRow => GetUserByShiftTypeCountOnDate(shiftCountRow.ShiftType.Guid, shiftCountByTypeColumn.Date, positionRow.UserRows));
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
        private int GetUserByShiftTypeCountOnDate(Guid type, DateTime date, List<IUserRowModel> userRows)
        {
            return userRows.Sum(userRow => GetUserShiftTypeCountOnDate(type, date, userRow.UserShiftTypeColumns));
        }

        /// <summary>
        /// Смены для сотрудников на этот день. 
        /// </summary>
        /// <param name="type">Тип смены</param>
        /// <param name="date">Дата</param>
        /// <param name="userShiftTypeColumns">Список смен для сотрудника на дату</param>
        /// <returns></returns>
        private int GetUserShiftTypeCountOnDate(Guid type, DateTime date, List<IUserShiftTypeColumn> userShiftTypeColumns)
        {
            if (userShiftTypeColumns == null)
            {
                return 0;
            }

            var userShiftTypeColumnOnDate = userShiftTypeColumns.FirstOrDefault(stRow => stRow.Date == date && stRow.Schedules != null);
            if (userShiftTypeColumnOnDate != null && userShiftTypeColumnOnDate.Schedules != null)
            {
                return userShiftTypeColumnOnDate.Schedules.Where(schedule => schedule.ShiftType.Guid == type).Count();
            }
            return 0;
        }

        /// <summary>
        /// Добавление расписаний смен для сотрудников
        /// </summary>
        /// <param name="scheduleResult">Результат выполнения ХП</param>
        /// <param name="userRow">Сотрудник</param>
        private void AddScheduleColumns(ScheduleShiftPersonalResult scheduleResult, IUserRowModel userRow)
        {
            if (!scheduleResult.ShiftPersonalScheduleId.HasValue)
            {
                return;
            }

            if (userRow.UserShiftTypeColumns == null)
            {
                userRow.UserShiftTypeColumns = new List<IUserShiftTypeColumn>();

                for (var currentDate = this._dateStart; currentDate <= this._dateEnd; currentDate = currentDate.AddDays(1))
                {
                    var newUserShiftTypeColumn = new UserShiftTypeColumn()
                    {
                        Date = currentDate
                    };
                    userRow.UserShiftTypeColumns.Add(newUserShiftTypeColumn);
                }
            }

            var userShiftTypeColumn = userRow.UserShiftTypeColumns.FirstOrDefault(ust => ust.Date == scheduleResult.ShiftPersonalScheduleDate.Value);
            if (userShiftTypeColumn == null)
            {
                userShiftTypeColumn = new UserShiftTypeColumn()
                {
                    Date = scheduleResult.ShiftPersonalScheduleDate.Value,
                    Schedules = new List<IShiftPersonalScheduleModel>()
                };

                userRow.UserShiftTypeColumns.Add(userShiftTypeColumn);
            }

            var shiftPersonalSchedule = new ShiftPersonalScheduleModel()
            {
                Id = scheduleResult.ShiftPersonalScheduleId.Value,
                Date = scheduleResult.ShiftPersonalScheduleDate.Value,
            };

            if (scheduleResult.ShiftTypeId.HasValue)
            {
                shiftPersonalSchedule.ShiftType = new ShiftTypeModel
                {
                    Id = scheduleResult.ShiftTypeId.Value,
                    Guid = scheduleResult.ShiftTypeGuid.Value,
                    Socr = scheduleResult.ShiftTypeDescr
                };
            }

            userShiftTypeColumn.Schedules.Add(shiftPersonalSchedule);
        }        

        #endregion
    }
}
