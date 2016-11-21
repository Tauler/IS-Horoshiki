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
using System.Linq;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.DAO.Helpers;

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
        public async Task<IShiftPersonalScheduleTableModel> GetTable(IShiftPersonalScheduleDataModel model)
        {
            try
            {
                return await this._shiftPersonalScheduleHelper.GetTable(model);                
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                throw new Exception(errorData.Message);
            }
        }

        /// <summary>
        /// Планирование смен сотрудника на определенный день
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ModelEntityModifyResult> UpdateCell(ICollection<IShiftPersonalScheduleModel> models)
        {
            try
            {
                var dates = models.Select(m => m.Date).Distinct();
                if (dates.Count() > 1)
                {
                    return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.CollectionDateMoreOne);
                }

                var users = models.Select(m => m.User).Distinct();
                if (users.Count() > 1)
                {
                    return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.CollectionUserMoreOne);
                }

                var shiftTypeIntensification = _unitOfWork.ShiftTypeRepository.GetIntensification();
                var shiftTypeIntensificationExist = models.Any(m => m.ShiftType != null && m.ShiftType.Id == shiftTypeIntensification.Id);
                if (shiftTypeIntensificationExist)
                {
                    if (models.Any(m => m.ShiftType.Id != shiftTypeIntensification.Id))
                    {
                        return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.ShiftTypeIntensificationWithAnyTypes);
                    }
                }

                foreach (var shiftPersonalScheduleModel in models)
                {
                    var validateResult = await _validator.ValidateAsync(shiftPersonalScheduleModel);
                    if (!validateResult.IsSucceeded)
                    {
                        return new ModelEntityModifyResult(validateResult.Errors);
                    }

                    if (shiftPersonalScheduleModel.Id > 0)
                    {
                        var resultModify = UpdatePersonalSchedule(shiftPersonalScheduleModel);
                        if (!resultModify.IsSucceeded)
                        {
                            return resultModify;
                        }
                    }
                    else
                    {
                        var resultModify = InsertPersonalSchedule(shiftPersonalScheduleModel);
                        if (!resultModify.IsSucceeded)
                        {
                            return resultModify;
                        }
                    }
                }

                _unitOfWork.Save();

                return new ModelEntityModifyResult();
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
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IShiftPersonalScheduleModel> ConvertTo(IEnumerable<ShiftPersonalSchedule> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonalSchedule CreateInternal(IShiftPersonalScheduleModel model)
        {
            return model.ToDaoEntity();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonalSchedule UpdateDaoInternal(ShiftPersonalSchedule daoEntity, IShiftPersonalScheduleModel model)
        {
            var result = daoEntity.Update(model);

            if (result.UserId > 0)
            {
                result.User = _unitOfWork.AccountRepository.GetById(result.UserId);
            }

            if (result.ShiftTypeId > 0)
            {
                result.ShiftType = _unitOfWork.ShiftTypeRepository.GetById(result.ShiftTypeId);
            }

            return daoEntity;
        }

        #endregion

        #region private

        /// <summary>
        /// Обновление расписания смены для сотрудника
        /// </summary>
        /// <param name="shiftPersonalScheduleModel">Модель расписания смены соотрудника</param>
        /// <returns></returns>
        private ModelEntityModifyResult UpdatePersonalSchedule(IShiftPersonalScheduleModel shiftPersonalScheduleModel)
        {
            shiftPersonalScheduleModel.ThrowIfNull();

            var daoSchedule = _unitOfWork.ShiftPersonalScheduleRepository.GetById(shiftPersonalScheduleModel.Id);
            if (daoSchedule == null)
            {
                var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { shiftPersonalScheduleModel.Id });
                return new ModelEntityModifyResult(errorData);
            }

            //при обновлении нельзя указывать другую дату
            if (shiftPersonalScheduleModel.Date != daoSchedule.Date)
            {
                return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.UpdateMistakeDate);
            }

            //при обновлении нельзя указывать другой тип
            if (shiftPersonalScheduleModel.ShiftType.Id != daoSchedule.ShiftTypeId)
            {
                return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.UpdateMistakeType);
            }

            //при обновлении нельзя указывать другого сотрудника
            if (shiftPersonalScheduleModel.User.Id != daoSchedule.UserId)
            {
                return new ModelEntityModifyResult(ShiftPersonalScheduleErrors.UpdateMistakeUser);
            }

            if (shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods != null)
            {
                foreach (var periodModel in shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods)
                {
                    InsertOrUpdatePeriod(daoSchedule.Id, periodModel);
                }
            }

            _unitOfWork.ShiftPersonalScheduleRepository.Update(daoSchedule);

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Добавить расписания смены для сотрудника
        /// </summary>
        /// <param name="shiftPersonalScheduleModel">Модель расписания смены соотрудника</param>
        /// <returns></returns>
        private ModelEntityModifyResult InsertPersonalSchedule(IShiftPersonalScheduleModel shiftPersonalScheduleModel)
        {
            shiftPersonalScheduleModel.ThrowIfNull();

            var existShiftType = _unitOfWork.ShiftTypeRepository.GetById(shiftPersonalScheduleModel.ShiftType.Id);
            if (existShiftType == null)
            {
                var errorData = new ErrorData(ShiftPersonalScheduleErrors.ShiftTypeNotFound, parameters: new object[] { shiftPersonalScheduleModel.ShiftType.Id });
                return new ModelEntityModifyResult(errorData);
            }

            var existUser = _unitOfWork.AccountRepository.GetById(shiftPersonalScheduleModel.User.Id);
            if (existUser == null)
            {
                var errorData = new ErrorData(ShiftPersonalScheduleErrors.UserNotFound, parameters: new object[] { shiftPersonalScheduleModel.User.Id });
                return new ModelEntityModifyResult(errorData);
            }

            var daoSchedule = CreateInternal(shiftPersonalScheduleModel);

            if (daoSchedule.ShiftPersonalSchedulePeriods != null)
            {
                foreach (var daoSchedulePeriod in daoSchedule.ShiftPersonalSchedulePeriods)
                {
                    daoSchedulePeriod.ShiftPersonalSchedule = daoSchedule;
                    daoSchedulePeriod.ShiftPersonalScheduleId = daoSchedule.Id;
                }
            }

            //if (daoSchedule.ShiftPersonalSchedulePeriods != null)
            //{
            //    daoSchedule.ShiftPersonalSchedulePeriods.Clear();
            //}

            _unitOfWork.ShiftPersonalScheduleRepository.Insert(daoSchedule);

            //if (shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods != null)
            //{
            //    foreach (var periodModel in shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods)
            //    {
            //        InsertOrUpdatePeriod(1, periodModel);
            //    }
            //}

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Обновить или вставить период работы сотрдника для смены
        /// </summary>
        /// <param name="periodModel"></param>
        /// <returns></returns>
        private ModelEntityModifyResult InsertOrUpdatePeriod(int daoScheduleId, IShiftPersonalSchedulePeriodModel periodModel)
        {
            periodModel.ThrowIfNull();
            daoScheduleId.ThrowIfNull();

            if (periodModel.Id > 0)
            {
                var daoPeriod = _unitOfWork.ShiftPersonalSchedulePeriodRepository.GetById(periodModel.Id);
                if (daoPeriod == null)
                {
                    var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { periodModel.Id });
                    return new ModelEntityModifyResult(errorData);
                }

                daoPeriod.StartTime = periodModel.StartTime;
                daoPeriod.StopTime = periodModel.StopTime;

                _unitOfWork.ShiftPersonalSchedulePeriodRepository.Update(daoPeriod);
            }
            else
            {
                var daoPeriod = new ShiftPersonalSchedulePeriod();
                daoPeriod.ShiftPersonalScheduleId = daoScheduleId;
                daoPeriod.StartTime = periodModel.StartTime;
                daoPeriod.StopTime = periodModel.StopTime;

                _unitOfWork.ShiftPersonalSchedulePeriodRepository.Insert(daoPeriod);
            }

            return new ModelEntityModifyResult();
        }

        #endregion
    }
}
