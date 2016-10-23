using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Integrations;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Integrations.Queues
{
    /// <summary>
    /// Нормализация чека
    /// </summary>
    public class NormalizationCheck : INormalizationCheck
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
        public NormalizationCheck(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region public методы

        /// <summary>
        /// Нормализация чека для его сохранения
        /// </summary>
        /// <param name="check">Чек 1С</param>
        /// <returns>Нормализованное состояние чека</returns>
        public async Task<SaleCheck> ExecuteNormalization(IntegrationCheck check)
        {
            var dateDoc = ToDate(check.DateDoc);

            return new SaleCheck()
            {
                IdCheck = check.IdCheck,
                DateDoc = dateDoc,
                Sum = 0,
                BuyProcessId = null,
                SubDepartments = await GetSubDepartaments(check),
                PlanCookingStart = ToDate(check.PlanCookingDateStart, check.PlanCookingTimeStart),
                FactCookingStart = null,
                PlanCookingEnd = ToDate(check.PlanCookingDateEnd, check.PlanCookingTimeEnd),
                FactCookingEnd = null,
                PlanPackingStart = null,
                FactPackingStart = null,
                PlanPackingEnd = null,
                FactPackingEnd = null,
                PlanDeliveryStart = ToDate(check.DateDelivery, check.TimeDelivery),
                FactDeliveryStart = null,
                PlanDeliveryEnd = null,
                FactDeliveryEnd = null,
                PlatformId = await GetPlatform(check)
            };
        }

        #endregion

        #region public методы

        /// <summary>
        /// Отделы для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private async Task<ICollection<SubDepartment>> GetSubDepartaments(IntegrationCheck check)
        {
            var isCool = ToBool(check.IsCoolSubDepartment);
            var IsPizza = ToBool(check.IsPizzaSubDepartment);
            var isSushi = ToBool(check.IsSushiSubDepartment);

            return await _unitOfWork.SubDepartmentRepository.GetSubDepartamentsAsync(isCool, IsPizza, isSushi);
        }

        /// <summary>
        /// Площадка для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private Task<int> GetPlatform(IntegrationCheck check)
        {
            return Task<int>.Factory.StartNew(() => 1);
        }

        /// <summary>
        /// Получить дату
        /// </summary>
        /// <param name="date">строка с датой</param>
        /// <returns></returns>
        private DateTime? ToDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date.Replace(" ", ""), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Получить время
        /// </summary>
        /// <param name="time">строка со временем</param>
        /// <returns></returns>
        private TimeSpan? ToTime(string time)
        {
            TimeSpan result;
            if (TimeSpan.TryParse(time.Replace(".", ":").Replace(" ", ""), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Создание даты со временем
        /// </summary>
        /// <param name="date">строка с датой</param>
        /// <param name="time">строка со временем</param>
        /// <returns></returns>
        private DateTime? ToDate(string date, string time)
        {
            var date1 = ToDate(date);
            var time1 = ToTime(time);
            return ToDate(date1, time1);
        }

        /// <summary>
        /// Создание даты со временем
        /// </summary>
        /// <param name="date">дата</param>
        /// <param name="time">время</param>
        /// <returns></returns>
        private DateTime? ToDate(DateTime? date, TimeSpan? time)
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
