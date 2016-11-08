using System.Collections.Generic;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Threading.Tasks;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using System;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules;
using IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Планирования графика работы сотрудников на период
    /// </summary>
    public class ShiftPersonalScheduleService : BaseEditableService<IShiftPersonalScheduleModel, IShiftPersonalScheduleValidator, ShiftPersonalSchedule, IShiftPersonalScheduleRepository>, IShiftPersonalScheduleService
    {
        #region Конструктор

        /// <summary>
        /// Хелпер построения График (расписание) смен сотрудников
        /// </summary>
        private readonly IShiftPersonalScheduleHelper _shiftPersonalScheduleHelper;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        /// <param name="shiftPersonalScheduleHelper">Валидатор</param>
        public ShiftPersonalScheduleService(UnitOfWork unitOfWork, IShiftPersonalScheduleValidator validator, IShiftPersonalScheduleHelper shiftPersonalScheduleHelper)
             : base(unitOfWork, unitOfWork.ShiftPersonalScheduleRepository, validator)
        {
            this._shiftPersonalScheduleHelper = shiftPersonalScheduleHelper;
        }

        #endregion

        #region IShiftPersonalScheduleService

        /// <summary>
        /// Таблица Планирования графика работы сотрудников на период
        /// </summary>
        /// <param name="model"> Планирования графика работы сотрудников на период</param>
        /// <returns></returns>
        public async Task<IShiftPersonalScheduleReportModel> GetReport(IShiftPersonalScheduleModel model)
        {
            try
            {
                return await this._shiftPersonalScheduleHelper.GetReport(model);                
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                throw new Exception(errorData.Message);
            }
        }
        
        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IShiftPersonalScheduleModel ConvertTo(ShiftPersonalSchedule daoEntity)
        {
            return new ShiftPersonalScheduleModel();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IShiftPersonalScheduleModel> ConvertTo(IEnumerable<ShiftPersonalSchedule> collection)
        {
            return new List<IShiftPersonalScheduleModel>();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonalSchedule CreateInternal(IShiftPersonalScheduleModel model)
        {
            return new ShiftPersonalSchedule();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonalSchedule UpdateDaoInternal(ShiftPersonalSchedule daoEntity, IShiftPersonalScheduleModel model)
        {
            return daoEntity;
        }

        #endregion
    }
}
