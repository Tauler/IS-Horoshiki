using IsHoroshiki.BusinessEntities.Editable.Interfaces;
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

namespace IsHoroshiki.BusinessServices.Editable.MonthObjectives
{
    /// <summary>
    /// Создать цель на месяц, если не существует.
    /// Если существует подтягиваем данные из БД.
    public class MonthObjectiveHelper : IMonthObjectiveHelper
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
        public MonthObjectiveHelper(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IMonthObjectiveHelper

        /// <summary>
        /// Создать цель на месяц, если не существует.
        /// Если существует подтягиваем данные из БД.
        public async Task<IMonthObjectiveModel> Get(IMonthObjectiveModel model)
        {
            model.ThrowIfNull();
            model.Platform.ThrowIfNull();

            var daoMonthObjective = GetMonthObjectiveFromDatabase(model);

            return daoMonthObjective.ToModelEntity();
        }

        #endregion

        #region private

        /// <summary>
        /// Цель на месяц из БД. Если ее не существует, то создать и сохранить в БД.
        /// </summary>
        /// <param name="model">Модель</param>
        /// <param name="createIfNotExist">создать если не существует</param>
        /// <returns></returns>
        private MonthObjective GetMonthObjectiveFromDatabase(IMonthObjectiveModel model, bool createIfNotExist = true)
        {
            var existMonthObjective = _unitOfWork.MonthObjectiveRepository.Get(model.Platform.Id, model.Year, model.Month);
            if (existMonthObjective == null)
            {
                if (!createIfNotExist)
                {
                    return null;
                }

                existMonthObjective = CreateMonthObjective(model.Platform.Id, model.Year, model.Month);
                this._unitOfWork.MonthObjectiveRepository.Insert(existMonthObjective);
                this._unitOfWork.Save();
            }

            return existMonthObjective;
        }

        /// <summary>
        /// Создать пустую цель на месяц
        /// </summary>
        /// <returns></returns>
        private MonthObjective CreateMonthObjective(int platformId, int year, int month)
        {
            return new MonthObjective()
            {
                PlatformId = platformId,
                Year = year,
                Month = month
            };
        }

        #endregion
    }
}
