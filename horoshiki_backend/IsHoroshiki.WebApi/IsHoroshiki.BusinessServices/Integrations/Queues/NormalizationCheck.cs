using IsHoroshiki.DAO;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.Integrations;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using IsHoroshiki.BusinessServices.Helpers;
using System.Threading;
using System.Globalization;

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

        /// <summary>
        /// Id площадки
        /// </summary>
        private static int? _platformId;

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
            if (string.IsNullOrEmpty(check.DateDoc))
            {
                Logger.Error("NormalizationCheck check.DateDoc IsNullOrEmpty!");
            }

            var dateDoc = ToDate(check.DateDoc);
            return new SaleCheck()
            {
                IdCheck = check.IdCheck,
                DateDoc = dateDoc,
                Sum = 0,
                BuyProcessId = GetBuyProcess(check),
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
                PlatformId = GetPlatform(check)
            };
        }

        #endregion

        #region private методы

        /// <summary>
        /// Способ покупки
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private int? GetBuyProcess(IntegrationCheck check)
        {
            Guid guid;
            if (check.Zona.TrimProbel() == "2" 
                || check.Zona.TrimProbel() == "3" 
                || check.Zona.TrimProbel() == "4")
            {
                guid = DatabaseConstant.BuyProcessDelivery;
            }
            else
            {
                guid = DatabaseConstant.BuyProcessSelf;
            }
           
            var exist = _unitOfWork.BuyProcessPepository.GetByGuid(guid);
            if (exist != null)
            {
                return exist.Id;
            }

            return null;
        }

        /// <summary>
        /// Отделы для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private async Task<ICollection<SubDepartment>> GetSubDepartaments(IntegrationCheck check)
        {
            var subDepartament = await _unitOfWork.SubDepartmentRepository.GetSubDepartamentsPizzaAsync();
            return new List<SubDepartment>()
            {
                subDepartament
            };
        }

        /// <summary>
        /// Площадка для чека
        /// </summary>
        /// <param name="check">Чек</param>
        /// <returns></returns>
        private int GetPlatform(IntegrationCheck check)
        {
            if (_platformId.HasValue)
            {
                return _platformId.Value;
            }

            int tempPlatformId = 0;
            var platformId = ConfigurationSettings.AppSettings["PlatformId"];
            if (platformId != null && int.TryParse(platformId, out tempPlatformId))
            {
                _platformId = tempPlatformId;
            }
            else
            {
                Logger.Error("NormalizationCheck значение площадки = 1 взято по умлочанию!");
            }

            _platformId = 1;
            return _platformId.Value;
        }

        /// <summary>
        /// Получить дату
        /// </summary>
        /// <param name="date">строка с датой</param>
        /// <returns></returns>
        private DateTime? ToDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }

            DateTime result;
            if (DateTime.TryParseExact(date.TrimProbel(), "dd.MM.yy", Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                Logger.Error("NormalizationCheck невозможно конвертировать дату из чека! Date: {0}, CurrentCulture: {1}",
                    date, Thread.CurrentThread.CurrentCulture.Name);
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
            if (string.IsNullOrEmpty(time))
            {
                return null;
            }

            time = time.Replace(".", ":").TrimProbel();
            TimeSpan result;
            if (TimeSpan.TryParseExact(time, "g", Thread.CurrentThread.CurrentCulture, TimeSpanStyles.None, out result))
            {
                return result;
            }
            else
            {
                Logger.Error("NormalizationCheck невозможно конвертировать время из чека! Time={0}", time);
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
            var val = value.TrimProbel();
            if (val == "0")
            {
                return false;
            }
            else if (val == "1")
            {
                return true;
            }

            bool result;
            bool.TryParse(val, out result);
            return result;
        }
        
        #endregion
    }
}
