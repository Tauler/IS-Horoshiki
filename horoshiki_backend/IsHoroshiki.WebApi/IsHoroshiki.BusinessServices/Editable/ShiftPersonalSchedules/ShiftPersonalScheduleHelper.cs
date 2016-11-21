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
            model.Platform.ThrowIfNull();
            model.Departament.ThrowIfNull();
            model.Date.ThrowIfNull();

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

            DateTime dateStart, dateEnd;
            ExtractPeriod(model, out dateStart, out dateEnd);

            var result = GetEmptyTable(model, dateStart, dateEnd);

          
            //result.SalePlanCountColumns = GetSalePlanCountColumns(dateStart, dateEnd, result);
       
            //var schedulerShiftPersonals = _unitOfWork.ShiftPersonalScheduleRepository.GetScheduleShiftPersonal(departaments, subDepartaments, model.Platform.Id, dateStart, dateEnd);

            //AddPositionScheduleRows(model, result, schedulerShiftPersonals);

            //result.UserCountByShiftTypeRows = GetUserCountByShiftTypeRows(result);
            
            //await UpdateNameTrainee(result);

            return result;
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






        ///// <summary>
        ///// Кол-во чеков за период
        ///// </summary>
        ///// <param name="model">Данные с фронта</param>
        ///// <param name="dateStart">Начало периода</param>
        ///// <param name="dateEnd">Окончание периода</param>
        ///// <param name="report">Отчет</param>
        ///// <returns></returns>
        //private List<ISalePlanCountColumnModel> GetSalePlanCountColumns(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel report)
        //{
        //    var result = new List<ISalePlanCountColumnModel>();

        //    Dictionary<DateTime, int> periods = _unitOfWork.SalePlanDayRepository.GetByCountPeriod(model.Platform.Id, (int)PlanType.Suchi, dateStart, dateStart);

        //    foreach (var headerColumn in report.HeaderScheduleColumns)
        //    {
        //        var column = new SalePlanCountColumnModel()
        //        {
        //            Date = headerColumn.Date,
        //        };

        //        if (periods.ContainsKey(headerColumn.Date))
        //        {
        //            column.Count = periods[headerColumn.Date];
        //        }

        //        result.Add(column);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Должности 
        ///// </summary>
        ///// <param name="model">Данные с фронта</param>
        ///// <param name="report">Отчет</param>
        ///// <returns></returns>
        //private void AddPositionScheduleRows(IShiftPersonalScheduleDataModel model,
        //    IShiftPersonalScheduleTableModel report,
        //    List<ScheduleShiftPersonalResult> scheduleShiftPersonalResults)
        //{
        //    if (report.PositionScheduleRows == null)
        //    {
        //        report.PositionScheduleRows = new List<IPositionScheduleRowModel>();
        //    }

        //    foreach (var scheduleResult in scheduleShiftPersonalResults)
        //    {
        //        if (!scheduleResult.PositionId.HasValue)
        //        {
        //            continue;
        //        }

        //        var positionRow = report.PositionScheduleRows.FirstOrDefault(p => p.Position.Id == scheduleResult.PositionId.Value);
        //        if (positionRow == null)
        //        {
        //            positionRow = new PositionScheduleRowModel();
        //            positionRow.Name = scheduleResult.PositionName + " на смене";
        //            positionRow.Position = new PositionModel
        //            {
        //                Id = scheduleResult.PositionId.Value,
        //                Guid = scheduleResult.PositionGuid.Value,
        //                Value = scheduleResult.PositionName
        //            };

        //            report.PositionScheduleRows.Add(positionRow);
        //        }

        //        AddUserRows(scheduleResult, positionRow);
        //    }
        //}

        ///// <summary>
        ///// Добавление пользователей
        ///// </summary>
        ///// <param name="scheduleResult">Результат выполнения ХП</param>
        ///// <param name="positionRow">Строка должности</param>
        //private void AddUserRows(ScheduleShiftPersonalResult scheduleResult, IPositionScheduleRowModel positionRow)
        //{
        //    if (positionRow.UserRows == null)
        //    {
        //        positionRow.UserRows = new List<IUserRowModel>();
        //    }

        //    if (!scheduleResult.UserId.HasValue)
        //    {
        //        return;
        //    }

        //    var userRow = positionRow.UserRows.FirstOrDefault(ur => ur.User.Id == scheduleResult.UserId.Value);
        //    if (userRow == null)
        //    {
        //        userRow = new UserRowModel();

        //        userRow.User = new ApplicationUserSmallModel()
        //        {
        //            Id = scheduleResult.UserId.Value,
        //            UserName = scheduleResult.UserName
        //        };

        //        positionRow.UserRows.Add(userRow);
        //    }

        //    if (scheduleResult.ShiftPersonalScheduleId.HasValue)
        //    {
        //        AddScheduleColumns(scheduleResult, userRow);
        //    }
        //}

        ///// <summary>
        ///// Добавление расписаний смен для сотрудников
        ///// </summary>
        ///// <param name="scheduleResult">Результат выполнения ХП</param>
        ///// <param name="userRow">Сотрудник</param>
        //private void AddScheduleColumns(ScheduleShiftPersonalResult scheduleResult, IUserRowModel userRow)
        //{
        //    if (userRow.ScheduleColumns == null)
        //    {
        //        userRow.ScheduleColumns = new List<IShiftPersonalScheduleModel>();
        //    }

        //    if (!scheduleResult.UserId.HasValue)
        //    {
        //        return;
        //    }

        //    var userRow = positionRow.UserRows.FirstOrDefault(ur => ur.User.Id == scheduleResult.UserId.Value);
        //    if (userRow == null)
        //    {
        //        userRow = new UserRowModel()
        //        {
        //            Date = scheduleResult.DateDoc,
        //        };

        //        userRow.User = new ApplicationUserSmallModel()
        //        {
        //            Id = scheduleResult.UserId.Value,
        //            UserName = scheduleResult.UserName
        //        };

        //        positionRow.UserRows.Add(userRow);
        //    }

        //    if (scheduleResult.ShiftPersonalScheduleId.HasValue)
        //    {
        //        AddShiftPersonalSchedule(scheduleResult, userRow);
        //    }
        //}

        ///// <summary>
        ///// Добавить смены для пользователя
        ///// </summary>
        ///// <param name="scheduleResult">Результат выполнения ХП</param>
        ///// <param name="userRow">Строка с пользователем</param>
        //private void AddShiftPersonalSchedule(ScheduleShiftPersonalResult scheduleResult, IUserColumnModel userRow)
        //{
        //    userRow.ShiftPersonalSchedule = new ShiftPersonalScheduleModel
        //    {
        //        Id = scheduleResult.ShiftPersonalScheduleId.Value,
        //        ShiftType = new ShiftTypeModel
        //        {
        //            Id = scheduleResult.ShiftTypeId.Value,
        //            Socr = scheduleResult.ShiftTypeDescr
        //        },
        //        ShiftPersonalSchedulePeriods = new List<IShiftPersonalSchedulePeriodModel>()
        //    };

        //    if (scheduleResult.ShiftPersonalScheduleDate.HasValue)
        //    {
        //        userRow.ShiftPersonalSchedule.Date = scheduleResult.ShiftPersonalScheduleDate.Value;
        //    }

        //    if (scheduleResult.ShiftTypeId.HasValue)
        //    {
        //        userRow.ShiftPersonalSchedule.ShiftType = new ShiftTypeModel
        //        {
        //            Id = scheduleResult.ShiftTypeId.Value,
        //            Guid = scheduleResult.ShiftTypeGuid.Value,
        //            Socr = scheduleResult.ShiftTypeDescr
        //        };
        //    }
        //}
    
        ///// <summary>
        ///// Добавить постфикс к имени стажера
        ///// </summary>
        ///// <param name="result"></param>
        ///// <returns></returns>
        //private async Task UpdateNameTrainee(ShiftPersonalScheduleTableModel result)
        //{
        //    var list = await _unitOfWork.AccountRepository.GetAllSmallTrainee();
        //    foreach (var positionRow in result.PositionScheduleRows)
        //    {
        //        foreach (var userRow in positionRow.UserRows)
        //        {
        //            if (list.Any(user => user.Id == userRow.User.Id))
        //            {
        //                userRow.User.UserName += " (ст)";
        //            }
        //        }
        //    }
        //}

        #endregion
    }
}
