using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
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
        public async Task<IShiftPersonalScheduleReportModel> GetReport(IShiftPersonalScheduleModel model)
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

            var r = _unitOfWork.ShiftPersonalScheduleRepository.GetScheduleShiftPersonal(departaments, subDepartaments, model.Platform.Id, model.DateStart, model.DateEnd);

            return new ShiftPersonalScheduleReportModel();
        }

        #endregion
    }
}
