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
        /// Создать план
        /// </summary>
        public async Task<SalePlanResult> CreatePlan()
        {
            ISalePlanModel model = new SalePlanModel();
            model.SalePlanPeriod = new SalePlanPeriodModel()
            {
                Year = 2016,
                Month = 11
            };

            model.AnalizePeriod1 = new SalePlanPeriodModel()
            {
                Year = 2016,
                Month = 15
            };

            model.AnalizePeriod2 = new SalePlanPeriodModel()
            {
                Year = 2016,
                Month = 10
            };


            var result = new SalePlanResult();


            var startDate = new DateTime(1, model.SalePlanPeriod.Month, model.SalePlanPeriod.Year);


            var daysInMonth = DateTime.DaysInMonth(model.SalePlanPeriod.Month, model.SalePlanPeriod.Year);
            var endDate = new DateTime(daysInMonth, model.SalePlanPeriod.Month, model.SalePlanPeriod.Year);

            var plans = GetPLans(startDate, endDate);

            return result;
        }

        private List<SalePlanDay> GetPLans(DateTime startDate, DateTime endDate)
        {
            var plans = new List<SalePlanDay>();
            for (var current = startDate; current <= endDate; current = current.AddDays(1))
            {
                var plan = new SalePlanDay()
                {
                    Date = current,
                    DayOfWeek = current.DayOfWeek,
                    Delivery = 1,
                    Self = 2
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
