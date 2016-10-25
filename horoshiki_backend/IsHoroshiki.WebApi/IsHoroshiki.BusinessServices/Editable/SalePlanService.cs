using System.Collections.Generic;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using System;
using System.Linq;
using System.Globalization;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис План продаж
    /// </summary>
    public class SalePlanService : BaseEditableService<ISalePlanModel, ISalePlanValidator, SalePlan, ISalePlanRepository>, ISalePlanService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public SalePlanService(UnitOfWork unitOfWork, ISalePlanValidator validator)
             : base(unitOfWork, unitOfWork.SalePlanRepository, validator)
        {
           
        }

        #endregion

        #region ISalePlanService

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        public async Task<SalePlanTableModel> Add(ISalePlanModel model)
        {
            return await CreatePlan(model);
        }

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        public async Task<SalePlanTableModel> Update(ISalePlanModel model)
        {
            return await CreatePlan(model);
        }

        /// <summary>
        /// Редактировать cредний чек плана 
        /// </summary>
        public async Task<ModelEntityModifyResult> UpdateAverageCheck(ISalePlanModel model)
        {
            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        public async Task<ModelEntityModifyResult> UpdateCell(ISalePlanCellModel model)
        {
            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Создать план
        /// </summary>
        private async Task<SalePlanTableModel> CreatePlan(ISalePlanModel model)
        {
            if (model == null)
            {
                model = new SalePlanModel();
                model.SalePlanPeriod = new SalePlanPeriodModel()
                {
                    Year = 2016,
                    Month = 11
                };

                model.AnalizePeriod1 = new SalePlanPeriodModel()
                {
                    Year = 2015,
                    Month = 11
                };

                model.AnalizePeriod2 = new SalePlanPeriodModel()
                {
                    Year = 2016,
                    Month = 10
                };
            }

            var result = new SalePlanTableModel();
            result.SalePlan = model;

            var plans = GetPlans(model.SalePlanPeriod);
            var analize1 = GetPlans(model.AnalizePeriod1);
            var analize2 = GetPlans(model.AnalizePeriod2);

            var rows = new List<ISalePlanDataRowModel>();
            foreach (var plan in plans)
            {
                var planRow = new SalePlanDataRowModel();
                planRow.Plan = plan;
                rows.Add(planRow);
            }
           
            AddAnanlyze(analize1, rows);
            AddAnanlyze(analize2, rows, false);

            result.DataRows = rows;

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
            result.SumRow = planSumRow;

            return result;
        }

        private int GetSum(List<ISalePlanDayModel> list, bool isDelivery = true)
        {
            return isDelivery ? list.Sum(l => l.Delivery) : list.Sum(l => l.Self);
        }

        /// <summary>
        /// Заполнить данными анализа
        /// </summary>
        /// <param name="analize"></param>
        /// <param name="rows">Стрроки с планом</param>
        /// <param name="isFirstAnalize">true - заполнить Анализ 1</param>
        private void AddAnanlyze(List<ISalePlanDayModel> analize, List<ISalePlanDataRowModel> rows, bool isFirstAnalize = true)
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

        private List<ISalePlanDayModel> GetPlans(ISalePlanPeriodModel periodModel)
        {
            var startDate = new DateTime(periodModel.Year, periodModel.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(periodModel.Year, periodModel.Month);
            var endDate = new DateTime(periodModel.Year, periodModel.Month, daysInMonth);

            return GetPlans(startDate, endDate);
        }

        private List<ISalePlanDayModel> GetPlans(DateTime startDate, DateTime endDate)
        {
            var random = new Random();
            var plans = new List<ISalePlanDayModel>();
            for (var current = startDate; current <= endDate; current = current.AddDays(1))
            {
                var plan = new SalePlanDayModel()
                {
                    Date = current,
                    DayOfWeek = current.DayOfWeek,
                    DayOfWeekDescr = current.ToString("ddd", new CultureInfo("ru-Ru")),
                    Delivery = random.Next(500),
                    Self = random.Next(500),
                };
                plans.Add(plan);
            }
            return plans;
        }

        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override ISalePlanModel ConvertTo(SalePlan daoEntity)
        {
            return new SalePlanModel();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<ISalePlanModel> ConvertTo(IEnumerable<SalePlan> collection)
        {
            return new List<ISalePlanModel>();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SalePlan CreateInternal(ISalePlanModel model)
        {
            return new SalePlan();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SalePlan UpdateDaoInternal(SalePlan daoEntity, ISalePlanModel model)
        {
            return daoEntity;
        }

        #endregion
    }
}
