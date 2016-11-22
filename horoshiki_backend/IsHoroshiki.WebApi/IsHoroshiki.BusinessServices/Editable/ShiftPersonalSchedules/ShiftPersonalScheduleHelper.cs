using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Threading.Tasks;
using IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder;
using IsHoroshiki.DAO.Helpers;
using IsHoroshiki.DAO;

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
            if (departament.Guid == DatabaseConstant.Departament.Administration)
            {
                builder = new ShiftPersonalScheduleBulderAdministration(_unitOfWork, model);
            }
            else if (departament.Guid == DatabaseConstant.Departament.Courier)
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
