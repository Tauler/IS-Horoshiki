using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IShiftPersonalScheduleReportModel> GetReport(IShiftPersonalScheduleDataModel model)
        {
            model.Platform.ThrowIfNull();
            model.DateStart.ThrowIfNull();
            model.DateEnd.ThrowIfNull();

            List<int> departaments = null;
            if (model.Departaments != null)
            {
                departaments = model.Departaments.Select(d => d.Id).ToList();
            }

            List<int> subDepartaments = null;
            if (model.SubDepartaments != null)
            {
                subDepartaments = model.SubDepartaments.Select(d => d.Id).ToList();
            }

            var result = new ShiftPersonalScheduleReportModel();

            result.HeaderScheduleColumns = GetHeaderScheduleColumns(model);
            result.SalePlanCountColumns = GetSalePlanCountColumns(model, result);

            var schedulerShiftPersonals = _unitOfWork.ShiftPersonalScheduleRepository.GetScheduleShiftPersonal(departaments, subDepartaments, model.Platform.Id, model.DateStart, model.DateEnd);
           
            return result;
        }

        #endregion

        #region private

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<IHeaderScheduleColumnModel> GetHeaderScheduleColumns(IShiftPersonalScheduleDataModel model)
        {
            var result = new List<IHeaderScheduleColumnModel>();

            for (var currentDate = model.DateStart; currentDate <= model.DateEnd; currentDate = currentDate.AddDays(1))
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
        /// Заголовок таблицы
        /// </summary>
        /// <param name="model">Данные с фронта</param>
        /// <param name="report">Отчет</param>
        /// <returns></returns>
        private List<ISalePlanCountColumnModel> GetSalePlanCountColumns(IShiftPersonalScheduleDataModel model, IShiftPersonalScheduleReportModel report)
        {
            var result = new List<ISalePlanCountColumnModel>();

            Dictionary<DateTime, int> periods = _unitOfWork.SalePlanDayRepository.GetByCountPeriod(model.Platform.Id, (int)model.PlanType, model.DateStart, model.DateEnd);

            foreach (var headerColumn in report.HeaderScheduleColumns)
            {
                var column = new SalePlanCountColumnModel()
                {
                    Date = headerColumn.Date,
                };

                if (periods.ContainsKey(headerColumn.Date))
                {
                    column.Count = periods[headerColumn.Date];
                }

                result.Add(column);
            }

            return result;
        }

        #endregion
    }
}
