using IsHoroshiki.BusinessEntities.Account;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder
{
    /// <summary>
    /// Базовый класс таблицы графика
    /// </summary>
    internal abstract class ShiftPersonalScheduleBulder
    {
        #region поля и свойства

        /// <summary>
        /// UnitOfWork
        /// </summary>
        protected readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Фильтр для построения отчета
        /// </summary>
        protected readonly IShiftPersonalScheduleDataModel _model;

        /// <summary>
        /// Начало периода построения отчета
        /// </summary>
        protected readonly DateTime _dateStart;

        /// <summary>
        /// Окончание периода построения отчета
        /// </summary>
        protected readonly DateTime _dateEnd;

        /// <summary>
        /// Окончание периода построения отчета
        /// </summary>
        protected ShiftPersonalScheduleTableModel _table;

        /// <summary>
        /// Рузультат выполнения ХП в БД
        /// </summary>
        protected List<ScheduleShiftPersonalResult> _scheduleShiftPersonalResults;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="model">Фильтр для построения отчета</param>
        public ShiftPersonalScheduleBulder(UnitOfWork unitOfWork, IShiftPersonalScheduleDataModel model)
        {
            model.Platform.ThrowIfNull("Platform is null");
            model.Departament.ThrowIfNull("Departament is null");
            model.Date.ThrowIfNull("Date is null");

            _unitOfWork = unitOfWork;
            _model = model;

            ExtractPeriod(model, out _dateStart, out _dateEnd);
        }

        #endregion

        #region public

        /// <summary>
        /// Инициализация данных. Выполнение ХП в БД.
        /// </summary>
        public void Begin()
        {
            _scheduleShiftPersonalResults = GetScheduleShiftPersonal(_model, _dateStart, _dateEnd);
        }

        /// <summary>
        /// Создание пустой таблице
        /// </summary>
        public void CreateEmptyTable()
        {
            _table = new ShiftPersonalScheduleTableModel();
        }

        /// <summary>
        /// Создание заголовков таблицы - даты за период
        /// </summary>
        public void FillHeaderColumns()
        {
            _table.HeaderScheduleColumns = GetHeaderScheduleColumns(_dateStart, _dateEnd);
        }

        /// <summary>
        /// Подсчет чеков на день
        /// </summary>
        public void FillSalePlanColumns()
        {
            _table.SalePlanCountColumns = GetEmptySalePlanColumns(_dateStart, _dateEnd);
            FillSalePlanCountColumns(_model, _dateStart, _dateEnd, _table);
        }

        /// <summary>
        /// Создание должностей и сотрудников для должности
        /// </summary>
        public virtual void FillPositionColumns()
        {
            FillPositionScheduleRows(_scheduleShiftPersonalResults, _model, _dateStart, _dateEnd, _table);
        }

        /// <summary>
        /// Заполнение ячеек в таблице (смены или часы)
        /// </summary>
        public virtual void FillUserCellColumns()
        {

        }

        /// <summary>
        /// Подсчет смен для сотрудников
        /// </summary>
        public virtual void FillShiftCountColumns()
        {
            
        }

        /// <summary>
        /// Завершение построения. 
        /// </summary>
        public void End()
        {
            UpdateNameTrainee(_table);
        }

        /// <summary>
        /// Подсчет смен для сотрудников
        /// </summary>
        public ShiftPersonalScheduleTableModel GetResult()
        {
            return _table;
        }

        #endregion

        #region private

        /// <summary>
        /// Построение расписания
        /// </summary>
        /// <param name="model">Данные запроса</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <returns></returns>
        private List<ScheduleShiftPersonalResult> GetScheduleShiftPersonal(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd)
        {
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
            return scheduleShiftPersonalResults;
        }

        /// <summary>
        /// Даты начала и окончания для периода
        /// </summary>
        /// <param name="model">Данные запроса</param>
        /// <param name="startDate">Начало периода</param>
        /// <param name="endDate">Окончание периода</param>
        protected void ExtractPeriod(IShiftPersonalScheduleDataModel model, out DateTime startDate, out DateTime endDate)
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
        /// Кол-во чеков за период
        /// </summary>
        /// <param name="model">Данные с фронта</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <returns></returns>
        private void FillSalePlanCountColumns(IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            Dictionary<DateTime, int> periods = _unitOfWork.SalePlanDayRepository.GetByCountPeriod(model.Platform.Id, (int)PlanType.Suchi, dateStart, dateEnd);

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
        /// <param name="scheduleShiftPersonalResults">Результат выполнения ХП</param>
        /// <param name="model">Данные с фронта</param>
        /// <param name="dateStart">Начало периода</param>
        /// <param name="dateEnd">Окончание периода</param>
        /// <param name="table">График</param>
        /// <param name="isAddShiftTypes">Добавить смены для сотрудника</param>
        /// <returns></returns>
        private void FillPositionScheduleRows(List<ScheduleShiftPersonalResult> scheduleShiftPersonalResults, IShiftPersonalScheduleDataModel model, DateTime dateStart, DateTime dateEnd, IShiftPersonalScheduleTableModel table)
        {
            model.Platform.ThrowIfNull("Platform is null");
            model.Departament.ThrowIfNull("Departament is null");

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
        }

        /// <summary>
        /// Добавление пользователей
        /// </summary>
        /// <param name="scheduleResult">Результат выполнения ХП</param>
        /// <param name="positionRow">Строка должности</param>
        /// <param name="isAddShiftTypes">Добавить смены для сотрудника</param>
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

            if (scheduleResult.NormaHour.HasValue)
            {
                userRow.NormaHourColumn += scheduleResult.NormaHour.Value;
            }
        }

        /// <summary>
        /// Добавить постфикс к имени стажера
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private void UpdateNameTrainee(ShiftPersonalScheduleTableModel result)
        {
            var list = _unitOfWork.AccountRepository.GetAllSmallTrainee().Result;
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
