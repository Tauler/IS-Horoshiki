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
using IsHoroshiki.BusinessServices.Validators;

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
        /// Планирование смен сотрудника на определенный день.
        /// Удаляем ВСЕ что нет в списке
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ModelEntityModifyResult> UpdateCell(IShiftPersonalScheduleUpdateModel model)
        {
            try
            {
                model.User.ThrowIfNull("User is null");
                model.Date.ThrowIfNull("Date is nUll");

                var shiftPersonalSchedules = model.ShiftPersonalSchedules ?? new List<IShiftPersonalScheduleModel>();

                model.Date = model.Date.Date;
                foreach (var shiftPersonalScheduleModel in shiftPersonalSchedules)
                {
                    shiftPersonalScheduleModel.Date = shiftPersonalScheduleModel.Date.Date;
                }

                ValidationResult validateModelResult = ValidateModel(model, shiftPersonalSchedules);
                if (!validateModelResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(validateModelResult.Errors);
                }

                return await UpdateInternal(model, shiftPersonalSchedules);
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
        /// Валидация модели 
        /// </summary>
        /// <param name="model">Модель, которую надо обновлять</param>
        /// <param name="shiftPersonalSchedules">Список смен для сотрудника</param>
        /// <returns></returns>
        private ValidationResult ValidateModel(IShiftPersonalScheduleUpdateModel model, ICollection<IShiftPersonalScheduleModel> shiftPersonalSchedules)
        {
            var dates = shiftPersonalSchedules.Select(m => m.Date).Distinct();
            if (dates.Count() > 1)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionDateMoreOne);
            }

            if (dates.Any(d => d != model.Date))
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionDateMoreOne);
            }


            var users = shiftPersonalSchedules.Select(m => m.User).Distinct();
            if (users.Count() > 1)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionUserMoreOne);
            }

            if (users.Any(u => u == null || u.Id != model.User.Id))
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionUserMoreOne);
            }

            var shiftTypeIntensification = _unitOfWork.ShiftTypeRepository.GetIntensification();
            if (shiftTypeIntensification != null)
            {
                var shiftTypeIntensificationExist = shiftPersonalSchedules.Any(m => m.ShiftType != null && m.ShiftType.Id == shiftTypeIntensification.Id);
                if (shiftTypeIntensificationExist)
                {
                    if (shiftPersonalSchedules.Any(m => m.ShiftType.Id != shiftTypeIntensification.Id))
                    {
                        return new ValidationResult(ShiftPersonalScheduleErrors.ShiftTypeIntensificationWithAnyTypes);
                    }
                }
            }

            return new ValidationResult();
        }

        /// <summary>
        /// Планирование смен сотрудника на определенный день.
        /// Удаляем ВСЕ что нет в списке
        /// </summary>
        /// <param name="model">Модель, которую надо обновлять</param>
        /// <param name="shiftPersonalSchedules">Список смен для сотрудника</param>
        /// <returns></returns>
        private async Task<ModelEntityModifyResult> UpdateInternal(IShiftPersonalScheduleUpdateModel model, ICollection<IShiftPersonalScheduleModel> shiftPersonalSchedules)
        { 
            //удаляем все то нет в списке
            var existSchedulers = _repository.GetByParam(model.User.Id, model.Date);
            foreach (var existScheduler in existSchedulers.ToList())
            {
                if (!shiftPersonalSchedules.Any(c => c.Id == existScheduler.Id))
                {
                    _unitOfWork.ShiftPersonalScheduleRepository.Delete(existScheduler);
                }
            }

            foreach (var shiftPersonalScheduleModel in shiftPersonalSchedules)
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

        /// <summary>
        /// Обновление расписания смены для сотрудника
        /// </summary>
        /// <param name="shiftPersonalScheduleModel">Модель расписания смены соотрудника</param>
        /// <returns></returns>
        private ModelEntityModifyResult UpdatePersonalSchedule(IShiftPersonalScheduleModel shiftPersonalScheduleModel)
        {
            shiftPersonalScheduleModel.ThrowIfNull("shiftPersonalScheduleModel is null");

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
                //удаляем период, если его нет в списке
                var existsPeriods = _unitOfWork.ShiftPersonalSchedulePeriodRepository.GetByShiftPersonalScheduleId(shiftPersonalScheduleModel.Id);
                foreach (var existsPeriod in existsPeriods.ToList())
                {
                    if (!shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods.Any(c => c.Id == existsPeriod.Id))
                    {
                        _unitOfWork.ShiftPersonalSchedulePeriodRepository.Delete(existsPeriod);
                    }
                }

                foreach (var periodModel in shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods)
                {
                    InsertOrUpdatePeriod(daoSchedule.Id, periodModel);
                }
            }
            else
            {
                //удаляем период, т.к. его нет в списке
                var existsPeriods = _unitOfWork.ShiftPersonalSchedulePeriodRepository.GetByShiftPersonalScheduleId(shiftPersonalScheduleModel.Id);
                foreach (var existsPeriod in existsPeriods.ToList())
                {
                    _unitOfWork.ShiftPersonalSchedulePeriodRepository.Delete(existsPeriod);
                }
            }

            _unitOfWork.ShiftPersonalScheduleRepository.Update(daoSchedule);

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Добавить расписания смены для сотрудника.
        /// Проверяем, если ID = 0, находим в БД по указаннмоу типу и дате.
        /// Если нет в БД, то создаем
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

            var daoSchedule = _repository.GetByParam(shiftPersonalScheduleModel.User.Id, shiftPersonalScheduleModel.ShiftType.Id, shiftPersonalScheduleModel.Date) 
                ?? CreateInternal(shiftPersonalScheduleModel);

            //если в БД существует, обновляем
            if (daoSchedule.Id > 0)
            {
                shiftPersonalScheduleModel.Id = daoSchedule.Id;

                var resultModify = UpdatePersonalSchedule(shiftPersonalScheduleModel);
                if (!resultModify.IsSucceeded)
                {
                    return resultModify;
                }
            }
            else
            {
                _unitOfWork.ShiftPersonalScheduleRepository.Insert(daoSchedule);
            }

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Обновить или вставить период работы сотрдника для смены
        /// </summary>
        /// <param name="periodModel"></param>
        /// <returns></returns>
        private ModelEntityModifyResult InsertOrUpdatePeriod(int daoScheduleId, IShiftPersonalSchedulePeriodModel periodModel)
        {
            periodModel.ThrowIfNull("periodModel is null");
            daoScheduleId.ThrowIfNull("daoScheduleId = 0");

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
