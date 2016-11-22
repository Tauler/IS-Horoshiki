using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Построение таблиц графика (расписания) смен сотрудников
    /// </summary>
    public class ShiftPersonalScheduleHelper : IShiftPersonalScheduleHelper
    {
        #region поля и свойства

        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        public ShiftPersonalScheduleHelper(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IShiftPersonalScheduleHelper

        /// <summary>
        /// График (расписание) смен сотрудников
        /// </summary>
        public async Task<IShiftPersonalScheduleTableModel> GetTable(IShiftPersonalScheduleDataModel model)
        {
            model.Platform.ThrowIfNull("Platform is null");
            model.Departament.ThrowIfNull("Departament is null");
            model.Date.ThrowIfNull("Date is null");
          
            DateTime dateStart, dateEnd;
            ExtractPeriod(model, out dateStart, out dateEnd);

            var table = GetEmptyTable(model, dateStart, dateEnd);


            FillSalePlanCountColumns(model, dateStart, dateEnd, table);
            FillPositionScheduleRows(model, dateStart, dateEnd, table);
            FillShiftCountRows(table);

            await UpdateNameTrainee(table);

            return table;
        }

        #endregion

        #region private

        /// <summary>
        /// Даты начала и окончания для периода
        /// </summary>
        /// <param name="model">Данные запроса</param>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Окончание периода</param>
        private void ExtractPeriod(IShiftPersonalScheduleDataModel model, out DateTime startDate, out DateTime endDate)
        {
            if (model.IsOnDay)
            {
                startDate = model.Date;
                endDate = model.Date;
            }
            else
            {
                startDate = new DateTime(model.Date.Year, model.Date.Month, 1);
                var daysInMonth = DateTime.DaysInMonth(model.Date.Year, model.Date.Month);
                endDate = new DateTime(model.Date.Year, model.Date.Month, daysInMonth);
            }
        }

        /// <summary>
        /// Создание пустой таблицы с незаполнеными столбцами
        /// </summary>
        /// <param name="model">Данные запроса</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        private ShiftPersonalScheduleTableModel GetEmptyTable(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd)
        {
            var result = new ShiftPersonalScheduleTableModel();

            result.HeaderScheduleColumns = GetHeaderScheduleColumns(dateStart, dateEnd);
            result.SalePlanCountColumns = GetEmptySalePlanColumns(dateStart, dateEnd);
            result.ShiftCountRow = GetEmptyShiftCountRow(dateStart, dateEnd);

            return result;
        }

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        private List<IHeaderScheduleColumnModel> GetHeaderScheduleColumns(DateTime dateStart, DateTime dateEnd)
        {
            var result = new List<IHeaderScheduleColumnModel>();

            for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
            {
                var column = new HeaderScheduleColumnModel()
                {
                    Date = currentDate,
                    DayOfWeekDescr = currentDate.ToString("ddd", new CultureInfo("ru-Ru"))
                };
                result.Add(column);
            }
                        
            return result;
        }

        /// <summary>
        /// Создание пустых столбцов для кол-ва чеков на этот день
        /// </summary>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        private List<ISalePlanCountColumnModel> GetEmptySalePlanColumns(DateTime dateStart, DateTime dateEnd)
        {
            var result = new List<ISalePlanCountColumnModel>();

            for (var currentDate = dateStart; currentDate <= dateEnd; currentDate = currentDate.AddDays(1))
            {
                var column = new SalePlanCountColumnModel()
                {
                    Date = currentDate
                };
                result.Add(column);
            }

            return result;
        }

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
        /// Кол-во чеков за период
        /// </summary>
        /// <param name="model">Данные с фронта</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillSalePlanCountColumns(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            Dictionary<DateTime, int> periods = _unitOfWork.SalePlanDayRepository.GetByCountPeriod(model.Platform.Id, (int)PlanType.Suchi, dateStart, dateStart);

            foreach (var headerColumn in table.SalePlanCountColumns)
            {
                if (periods.ContainsKey(headerColumn.Date))
                {
                    headerColumn.Count = periods[headerColumn.Date];
                }
            };
        }

        /// <summary>
        /// Должности 
        /// </summary>
        /// <param name="model">Данные с фронта</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillPositionScheduleRows(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            model.Platform.ThrowIfNull("Platform is null");
            model.Departament.ThrowIfNull("Departament is null");

            List<int> departaments = null;
            if (model.Departament != null)
            {
                departaments = new List<int>() { model.Departament.Id };
            }

            List<int> subDepartaments = null;
            if (model.SubDepartaments != null)
            {
                subDepartaments = model.SubDepartaments.Select(d => d.Id).ToList();
            }

            var scheduleShiftPersonalResults = _unitOfWork.ShiftPersonalScheduleRepository.GetScheduleShiftPersonal(departaments, subDepartaments, model.Platform.Id, dateStart, dateEnd);

            var result = new List<IPositionScheduleRowModel>();
            foreach (var scheduleResult in scheduleShiftPersonalResults)
            {
                if (!scheduleResult.PositionId.HasValue)
                {
                    continue;
                }

                var positionRow = result.FirstOrDefault(p => p.Position.Id == scheduleResult.PositionId.Value);
                if (positionRow == null)
                {
                    positionRow = new PositionScheduleRowModel();
                    positionRow.Name = scheduleResult.PositionName;
                    positionRow.Position = new PositionModel
                    {
                        Id = scheduleResult.PositionId.Value,
                        Guid = scheduleResult.PositionGuid.Value,
                        Value = scheduleResult.PositionName
                    };

                    result.Add(positionRow);
                }

                AddUserRows(scheduleResult, positionRow);
            }

            table.PositionScheduleRows = result;

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
                    shiftCountResultColumn.Count = GetUserShiftTypeCountOnDate(Guid.Empty, shiftCountResultColumn.Date, positionScheduleRow.UserRows);
                }
            }
        }

        /// <summary>
        /// Группировка смен по дням
        /// </summary>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillShiftCountRows(IShiftPersonalScheduleTableModel table)
        {
            foreach (var shiftCountRow in table.ShiftCountRow.ShiftCountByTypeRows)
            {
                foreach (var shiftCountByTypeColumn in shiftCountRow.ShiftCountByTypeColumns)
                {
                    shiftCountByTypeColumn.Count = table.PositionScheduleRows.Sum(positionRow => GetUserShiftTypeCountOnDate(shiftCountRow.ShiftType.Guid, shiftCountByTypeColumn.Date, positionRow.UserRows));
                }
            }
        }

        /// <summary>
        /// Смены для сотрудников на этот день
        /// </summary>
        /// <param name="type">Тип смены</param>
        /// <param name="date">Дата</param>
        /// <param name="userRows">Список сотрудников</param>
        /// <returns></returns>
        private int GetUserShiftTypeCountOnDate(Guid type, DateTime date, List<IUserRowModel> userRows)
        {
            return userRows.Sum(userRow => GetUserShiftTypeCountOnDate(type, date, userRow.UserShiftTypeColumns));
        }

        /// <summary>
        /// Смены для сотрудников на этот день
        /// </summary>
        /// <param name="type">Тип смены</param>
        /// <param name="date">Дата</param>
        /// <param name="userShiftTypeColumns">Список смен для сотрудника на дату</param>
        /// <returns></returns>
        private int GetUserShiftTypeCountOnDate(Guid type, DateTime date, List<IUserShiftTypeColumn> userShiftTypeColumns)
        {
            var userShiftTypeColumnOnDate = userShiftTypeColumns.FirstOrDefault(stRow => stRow.Date == date && stRow.Schedules != null);
            if (userShiftTypeColumnOnDate != null)
            {
                if (type != Guid.Empty)
                {
                    return userShiftTypeColumnOnDate.Schedules.Where(schedule => schedule.ShiftType.Guid == type).Count();
                }
                else
                {
                    return userShiftTypeColumnOnDate.Schedules.Count();
                }
            }
            return 0;
        }

        /// <summary>
        /// Добавление пользователей
        /// </summary>
        /// <param name="scheduleResult">Результат выполнения ХП</param>
        /// <param name="positionRow">Строка должности</param>
        private void AddUserRows(ScheduleShiftPersonalResult scheduleResult, IPositionScheduleRowModel positionRow)
        {
            if (positionRow.UserRows == null)
            {
                positionRow.UserRows = new List<IUserRowModel>();
            }

            if (!scheduleResult.UserId.HasValue)
            {
                return;
            }

            var userRow = positionRow.UserRows.FirstOrDefault(ur => ur.User.Id == scheduleResult.UserId.Value);
            if (userRow == null)
            {
                userRow = new UserRowModel();

                userRow.User = new ApplicationUserSmallModel()
                {
                    Id = scheduleResult.UserId.Value,
                    UserName = scheduleResult.UserName
                };

                positionRow.UserRows.Add(userRow);
            }

            userRow.NormaHourColumn += scheduleResult.NormaNormaHour;

            if (scheduleResult.ShiftPersonalScheduleId.HasValue)
            {
                AddScheduleColumns(scheduleResult, userRow);
            }
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
        
        /// <summary>
        /// Добавить постфикс к имени стажера
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task UpdateNameTrainee(ShiftPersonalScheduleTableModel result)
        {
            var list = await _unitOfWork.AccountRepository.GetAllSmallTrainee();
            foreach (var positionRow in result.PositionScheduleRows)
            {
                foreach (var userRow in positionRow.UserRows)
                {
                    if (list.Any(user => user.Id == userRow.User.Id))
                    {
                        userRow.User.UserName += " (ст)";
                    }
                }
            }
        }

        #endregion
    }
}
