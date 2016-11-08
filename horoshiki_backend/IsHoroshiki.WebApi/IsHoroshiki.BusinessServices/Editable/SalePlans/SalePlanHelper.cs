using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Reports;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.SalePlans
{
    /// <summary>
    /// Создать план, если не существует на указанный период.
    /// Если существует подтягиваем данные из БД.
    /// </summary>
    public class SalePlanHelper : ISalePlanHelper
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
        public SalePlanHelper(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region ISalePlanHelper

        /// <summary>
        /// Создать план, если не существует на указанный период.
        /// Если существует подтягиваем данные из БД.
        /// </summary>
        public async Task<ISalePlanTableModel> Get(ISalePlanModel model)
        {
            model.ThrowIfNull();
            model.Platform.ThrowIfNull();
            model.SalePlanPeriod.ThrowIfNull();
            model.AnalizePeriod1.ThrowIfNull();
            model.AnalizePeriod2.ThrowIfNull();

            var daoSalePlan = GetPlanFromDatabase(model);

            ISalePlanTableModel result = new SalePlanTableModel();

            result.SalePlan = model;
            result.SalePlan.Id = daoSalePlan.Id;
            result.SalePlan.AverageCheck = daoSalePlan.AverageCheck;

            var plans = GetSaleDayPlans(daoSalePlan);
            var analize1 = GetAnalize(model.Platform.Id, model.AnalizePeriod1, model.PlanType == PlanType.Suchi);
            var analize2 = GetAnalize(model.Platform.Id, model.AnalizePeriod2, model.PlanType == PlanType.Suchi);

            List<ISalePlanDataRowModel> rows = AddRowPlan(plans);
            AddRowAnanlyze(analize1, rows);
            AddRowAnanlyze(analize2, rows, false);

            result.DataRows = rows;
            result.SumRow = AddRowSum(result);

            return result;
        }

        /// <summary>
        /// Отчет плана продаж
        /// </summary>
        public async Task<ISalePlanReportModel> GetReport(ISalePlanModel model)
        {
            model.ThrowIfNull();
            model.Platform.ThrowIfNull();
            model.SalePlanPeriod.ThrowIfNull();

            var result = new SalePlanReportModel();

            result.SalePlan = model;
            result.DataRows = GetReportDataRows(model.SalePlanPeriod);
            CalculateReport(model, PlanType.Pizza, result);
            CalculateReport(model, PlanType.Suchi, result);
            result.SumRow = GetReportDataRows(result.DataRows);

            return result;
        }

        #endregion

        #region private

        /// <summary>
        /// Подсчитать суммы
        /// </summary>
        /// <param name="model">План</param>
        /// <param name="planType">тип плана</param>
        /// <param name="result">Результат</param>
        /// <returns></returns>
        private void CalculateReport(ISalePlanModel model, PlanType planType, SalePlanReportModel result)
        {
            model.PlanType = planType;

            var existPlan = GetPlanFromDatabase(model, false);
            if (existPlan == null)
            {
                return;
            }

            foreach (var salePlanData in result.DataRows)
            {
                var resultCalc = existPlan.SalePlanDays
                    .Where(sp => salePlanData.DateStart <= sp.Date && sp.Date <= salePlanData.DateEnd)
                    .Sum(sp => (sp.Self + sp.Delivery)) * existPlan.AverageCheck;

                if (planType == PlanType.Pizza)
                {
                    salePlanData.Pizza += resultCalc;
                }
                else
                {
                    salePlanData.Sushi += resultCalc;
                }
            }
        }

        /// <summary>
        /// Подсчет суммы по неделям за период
        /// </summary>
        /// <param name="periodModel"></param>
        /// <returns></returns>
        private List<ISalePlanReportRowModel> GetReportDataRows(ISalePlanPeriodModel periodModel)
        {
            var result = new List<ISalePlanReportRowModel>();

            DateTime startDate, endDate;
            ExtractPeriod(periodModel, out startDate, out endDate);

            var row = new SalePlanReportRowModel();
            row.DateStart = startDate;
            row.DateEnd = endDate;

            //если пн - это начало периода
            if (row.DateStart.DayOfWeek != DayOfWeek.Monday)
            {
                result.Add(row);
            }

            for (var current = startDate; current <= endDate; current = current.AddDays(1))
            {


                if (current.DayOfWeek == DayOfWeek.Monday)
                {
                    row = new SalePlanReportRowModel();
                    row.DateStart = current;
                    row.DateEnd = current;
                    result.Add(row);
                }

                if (current.DayOfWeek == DayOfWeek.Sunday || current == endDate)
                {
                    row.DateEnd = current;
                }
            }

            return result;
        }

        /// <summary>
        /// Подсчет суммы отчета плана продаж
        /// </summary>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        private ISalePlanReportSumRowModel GetReportDataRows(List<ISalePlanReportRowModel> dataRows)
        {
            var result = new SalePlanReportSumRowModel();

            result.Pizza = dataRows.Sum(dr => dr.Pizza);
            result.Sushi = dataRows.Sum(dr => dr.Sushi);

            return result;
        }

        /// <summary>
        /// План продаж из БД. Если его не существует, то создать и сохранить в БД.
        /// </summary>
        /// <param name="model">Модель</param>
        /// <param name="createIfNotExist">создать если не существует</param>
        /// <returns></returns>
        private SalePlan GetPlanFromDatabase(ISalePlanModel model, bool createIfNotExist = true)
        {
            var existPlan = _unitOfWork.SalePlanRepository.GetByPeriod(model.Platform.Id, (int)model.PlanType, model.SalePlanPeriod.Year, model.SalePlanPeriod.Month);
            if (existPlan == null)
            {
                if (!createIfNotExist)
                {
                    return null;
                }

                existPlan = CreatePlan(model.Platform.Id, model.PlanType, model.SalePlanPeriod);

                _unitOfWork.SalePlanRepository.Insert(existPlan);

                foreach (var salePlanDay in existPlan.SalePlanDays)
                {
                    salePlanDay.SalePlanId = existPlan.Id;
                    _unitOfWork.SalePlanDayRepository.Insert(salePlanDay);
                }

                _unitOfWork.Save();
            }
            else
            {
                if (existPlan.SalePlanDays == null || existPlan.SalePlanDays.Count == 0)
                {
                    existPlan.SalePlanDays = _unitOfWork.SalePlanDayRepository.GetBySalePlan(existPlan.Id);
                }
            }

            return existPlan;
        }

        /// <summary>
        /// Создать пустой план
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        /// <param name="planType">Id типа плана</param>
        /// <param name="periodModel">Период планирования</param>
        /// <returns></returns>
        private SalePlan CreatePlan(int platformId, PlanType planType, ISalePlanPeriodModel periodModel)
        {
            DateTime startDate, endDate;
            ExtractPeriod(periodModel, out startDate, out endDate);

            var newPlan = new SalePlan();

            newPlan.PlatformId = platformId;
            newPlan.PlanTypeId = (int)planType;
            newPlan.Year = periodModel.Year;
            newPlan.Month = periodModel.Month;

            var dayPlans = new List<SalePlanDay>();
            for (var current = startDate; current <= endDate; current = current.AddDays(1))
            {
                var dayPlan = new SalePlanDay()
                {
                    Date = current,
                    Delivery = 0,
                    Self = 0,
                };

                dayPlans.Add(dayPlan);
            }

            newPlan.SalePlanDays = dayPlans;

            return newPlan;
        }

        /// <summary>
        /// Добавить строки с планом
        /// </summary>
        /// <param name="plans">Список дней с планом</param>
        /// <returns></returns>
        private List<ISalePlanDataRowModel> AddRowPlan(List<ISalePlanDayModel> plans)
        {
            var rows = new List<ISalePlanDataRowModel>();
            foreach (var plan in plans)
            {
                var planRow = new SalePlanDataRowModel();
                planRow.Plan = plan;
                rows.Add(planRow);
            }

            return rows;
        }

        /// <summary>
        /// Заполнить данными анализа
        /// </summary>
        /// <param name="analize"></param>
        /// <param name="rows">Стрроки с планом</param>
        /// <param name="isFirstAnalize">true - заполнить Анализ 1</param>
        private void AddRowAnanlyze(List<ISalePlanDayModel> analize, List<ISalePlanDataRowModel> rows, bool isFirstAnalize = true)
        {
            var rowsWithPlan = rows.Where(a => a.Plan != null).ToList();
            var firstDayOfWeekPlan = rowsWithPlan[0].Plan.DayOfWeek;

            var firstDayAnalize = analize.First(a => a.DayOfWeek == firstDayOfWeekPlan);
            var beforeFirstDayAnalize = analize.Where(a => a.Date < firstDayAnalize.Date).ToList();
            var afterFirstDayAnalize = analize.Where(a => a.Date >= firstDayAnalize.Date).ToList();

            for (int i = 0; i < afterFirstDayAnalize.Count; i++)
            {
                ISalePlanDataRowModel planRow;
                if (i > rows.Count - 1)
                {
                    planRow = new SalePlanDataRowModel();
                    rows.Add(planRow);
                }
                else
                {
                    planRow = rowsWithPlan[i];
                }

                if (isFirstAnalize)
                {
                    planRow.Analize1 = afterFirstDayAnalize[i];
                }
                else
                {
                    planRow.Analize2 = afterFirstDayAnalize[i];
                }
            }

            var rowsBeforePlan = rows.Except(rowsWithPlan).ToList();

            rowsBeforePlan.Reverse();
            beforeFirstDayAnalize.Reverse();

            for (int i = 0; i < beforeFirstDayAnalize.Count; i++)
            {
                ISalePlanDataRowModel planRow;
                if (i > rowsBeforePlan.Count - 1)
                {
                    planRow = new SalePlanDataRowModel();
                    rows.Insert(0, planRow);
                }
                else
                {
                    planRow = rowsBeforePlan[i];
                }

                if (isFirstAnalize)
                {
                    planRow.Analize1 = beforeFirstDayAnalize[i];
                }
                else
                {
                    planRow.Analize2 = beforeFirstDayAnalize[i];
                }
            }
        }

        /// <summary>
        /// Добавить результирующую строку
        /// </summary>
        /// <param name="result">Построенная таблица для подсчета суммы</param>
        /// <returns></returns>
        private SalePlanSumRowModel AddRowSum(ISalePlanTableModel result)
        {
            var planSumRow = new SalePlanSumRowModel();
            planSumRow.Plan = new SalePlanSumDayModel()
            {
                Delivery = GetSum(result.DataRows.Where(dr => dr.Plan != null).Select(dr => dr.Plan).ToList()),
                Self = GetSum(result.DataRows.Where(dr => dr.Plan != null).Select(dr => dr.Plan).ToList(), false),
            };

            planSumRow.Analize1 = new SalePlanSumDayModel()
            {
                Delivery = GetSum(result.DataRows.Where(dr => dr.Analize1 != null).Select(dr => dr.Analize1).ToList()),
                Self = GetSum(result.DataRows.Where(dr => dr.Analize1 != null).Select(dr => dr.Analize1).ToList(), false),
            };

            planSumRow.Analize2 = new SalePlanSumDayModel()
            {
                Delivery = GetSum(result.DataRows.Where(dr => dr.Analize2 != null).Select(dr => dr.Analize2).ToList()),
                Self = GetSum(result.DataRows.Where(dr => dr.Analize2 != null).Select(dr => dr.Analize2).ToList(), false),
            };
            return planSumRow;
        }

        /// <summary>
        /// Дни плана продаж
        /// </summary>
        /// <param name="daoSalePlan">План из БД</param>
        /// <returns></returns>
        private List<ISalePlanDayModel> GetSaleDayPlans(SalePlan daoSalePlan)
        {
            return daoSalePlan.SalePlanDays.ToModelEntityList().ToList();
        }

        /// <summary>
        /// Получить отчет-анализ за период
        /// </summary>
        /// <param name="idPlatform">id Площадки</param>
        /// <param name="start">Дата начала</param>
        /// <param name="end">Дата окончания</param>
        /// <param name="isSushi">true - если суши</param>
        private List<ISalePlanDayModel> GetAnalize(int platformId, ISalePlanPeriodModel periodModel, bool isSuchi)
        {
            DateTime startDate, endDate;
            ExtractPeriod(periodModel, out startDate, out endDate);

            var result = GetDefaultDayList(startDate, endDate);

            var saleAnalizeResult = _unitOfWork.SaleCheckRepository.GetSaleCheckAnalize(platformId, startDate, endDate, isSuchi);
            if (saleAnalizeResult == null || saleAnalizeResult.Count == 0)
            {
                return result;
            }

            foreach (var analizeDay in saleAnalizeResult)
            {
                var exist = result.FirstOrDefault(r => r.Date == analizeDay.DateDoc);
                if (exist != null)
                {
                    exist.Delivery = analizeDay.Delivery;
                    exist.Self = analizeDay.Self;
                }
            }

            return result;
        }

        /// <summary>
        /// Даты начала и окончания для периода
        /// </summary>
        /// <param name="periodModel">Период</param>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        private void ExtractPeriod(ISalePlanPeriodModel periodModel, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(periodModel.Year, periodModel.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(periodModel.Year, periodModel.Month);
            endDate = new DateTime(periodModel.Year, periodModel.Month, daysInMonth);
        }

        /// <summary>
        /// Список значений по умолчания для ячеек
        /// </summary>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <returns></returns>
        private List<ISalePlanDayModel> GetDefaultDayList(DateTime startDate, DateTime endDate)
        {
            var plans = new List<ISalePlanDayModel>();
            for (var current = startDate; current <= endDate; current = current.AddDays(1))
            {
                var plan = new SalePlanDayModel()
                {
                    Date = current,
                    DayOfWeek = current.DayOfWeek,
                    DayOfWeekDescr = current.ToString("ddd", new CultureInfo("ru-Ru")),
                    Delivery = 0,
                    Self = 0,
                };
                plans.Add(plan);
            }
            return plans;
        }

        /// <summary>
        /// Сумма за все дни
        /// </summary>
        /// <param name="list">Список дней</param>
        /// <param name="isDelivery">true - если доставка</param>
        /// <returns></returns>
        private int GetSum(List<ISalePlanDayModel> list, bool isDelivery = true)
        {
            return isDelivery ? list.Sum(l => l.Delivery) : list.Sum(l => l.Self);
        }

        #endregion
    }
}
