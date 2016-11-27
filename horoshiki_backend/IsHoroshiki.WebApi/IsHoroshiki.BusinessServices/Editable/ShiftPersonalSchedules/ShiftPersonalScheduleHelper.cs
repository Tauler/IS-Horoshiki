﻿using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Threading.Tasks;
using IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO;
using System.Linq;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;

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
            model.Platform.ThrowIfNull("Platform is null");
            model.Departament.ThrowIfNull("Departament is null");
            model.Date.ThrowIfNull("Date is null");

            ShiftPersonalScheduleBulder builder;

            var departament = _unitOfWork.DepartmentRepository.GetById(model.Departament.Id);
            var subDepartament = model.SubDepartaments != null ? _unitOfWork.SubDepartmentRepository.GetById(model.SubDepartaments.First().Id) : null;

            if (departament.Guid == DatabaseConstant.Departament.Administration)
            {
                builder = new ShiftPersonalScheduleBulderAdministration(_unitOfWork, model);
            }
            else if (departament.Guid == DatabaseConstant.Departament.Courier)
            {
                builder = new ShiftPersonalScheduleBulderCourier(_unitOfWork, model);
            }
            else if (departament.Guid == DatabaseConstant.Departament.Production &&
                model.SubDepartaments != null &&
                model.SubDepartaments.Count == 1 &&
                subDepartament.Guid == DatabaseConstant.SubDepartament.Cleaner)
            {
                builder = new ShiftPersonalScheduleBulderCourier(_unitOfWork, model);
            }
            else
            {
                builder = new ShiftPersonalScheduleBulderByType(_unitOfWork, model);
            }
                       
            var director = new ShiftPersonalScheduleDirector(builder);
            return director.CreateTable();
        }

        #endregion
    }
}
