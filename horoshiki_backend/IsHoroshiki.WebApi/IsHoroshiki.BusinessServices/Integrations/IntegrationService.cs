using IsHoroshiki.BusinessEntities.Integrations;
using IsHoroshiki.BusinessEntities.Integrations.MappingDao;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Threading.Tasks;
using IsHoroshiki.DAO.DaoEntities.Integrations;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using System.Collections.Generic;

namespace IsHoroshiki.BusinessServices.Integrations
{
    /// <summary>
    /// Сервис интеграции
    /// </summary>
    public class IntegrationService : IIntegrationService
    {
        #region IIntegrationService

        // <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        public async Task<bool> Save(IIntegrationCheckModel model)
        {
            return await SaveInternal(model);
        }

        #endregion

        #region private

        // <summary>
        /// Сохранить запись о чеки
        /// </summary>
        /// <param name="model">Модель</param>
        public async Task<bool> SaveInternal(IIntegrationCheckModel model)
        {
            try
            {
                var daoEntity = model.ToDaoEntity();
                daoEntity.DateReceive = DateTime.Now;

                using (var unit = new UnitOfWork())
                {
                    unit.IntegrationCheckRepository.Insert(daoEntity);
                    unit.Save();

                    //SaleCheck daoSaleCheck = await ConvertToDao(daoEntity);
                    //unit.SaleCheckRepository.Insert(daoSaleCheck);
                    //unit.Save();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private async Task<SaleCheck> ConvertToDao(IntegrationCheck check)
        {
            var dateDoc = ToDate(check.DateDoc);

            return new SaleCheck()
            {
                IdCheck = check.IdCheck,
                DateDoc = dateDoc,
                Sum = 0,
                BuyProcessId = 1,
                SubDepartments = await GetSubDepartaments(check),
                PlanCookingStart = Concate(check.PlanCookingDateStart, check.PlanCookingTimeStart),
                FactCookingStart = null,
                PlanCookingEnd = Concate(check.PlanCookingDateEnd, check.PlanCookingTimeEnd),
                FactCookingEnd = null,
                PlanPackingStart = null,
                FactPackingStart = null,
                PlanPackingEnd = null,
                FactPackingEnd = null,
                PlanDeliveryStart = Concate(check.DateDelivery, check.TimeDelivery),
                FactDeliveryStart = null,
                PlanDeliveryEnd = null,
                FactDeliveryEnd = null,
                PlatformId = await GetPlatform(check)
            };
        }

        /// <summary>
        /// Отделы для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private async Task<ICollection<SubDepartment>> GetSubDepartaments(IntegrationCheck check)
        {
            using (var unit = new UnitOfWork())
            {
                var isCool = ToBool(check.IsCoolSubDepartment);
                var IsPizza = ToBool(check.IsPizzaSubDepartment);
                var isSushi = ToBool(check.IsSushiSubDepartment);

                return await unit.SubDepartmentRepository.GetSubDepartamentsAsync(isCool, IsPizza, isSushi);
            }
        }

        /// <summary>
        /// Площадка для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private async Task<int> GetPlatform(IntegrationCheck check)
        {
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime? ToDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private TimeSpan? ToTime(string time)
        {
            TimeSpan result;
            if (TimeSpan.TryParse(time, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private DateTime? Concate(string date, string time)
        {
            var date1 = ToDate(date);
            var time1 = ToTime(time);
            return Concate(date1, time1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private DateTime? Concate(DateTime? date, TimeSpan? time)
        {
            if (!date.HasValue)
            {
                return null;
            }

            if (!time.HasValue)
            {
                return date.Value;
            }

            return date.Value.Add(time.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private bool ToBool(string value)
        {
            if (value == "0")
            {
                return false;
            }
            else if (value == "1")
            {
                return true;
            }

            bool result;
            bool.TryParse(value, out result);
            return result;
        }


        #endregion
    }
}
