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
                model.Date.ThrowIfNull("Date is null");

                if (model.ShiftPersonalSchedules == null)
                {
                    model.ShiftPersonalSchedules = new List<IShiftPersonalScheduleModel>();
                }

                model.Date = model.Date.Date;
                foreach (var shiftPersonalScheduleModel in model.ShiftPersonalSchedules)
                {
                    shiftPersonalScheduleModel.Date = shiftPersonalScheduleModel.Date.Date;
                }

                ValidationResult validateModelResult = ValidateModel(model);
                if (!validateModelResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(validateModelResult.Errors);
                }

                return await UpdateInternal(model);
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                throw new Exception(errorData.Message);
            }
        }

        /// <summary>
        /// Получение норма часов за период для пользователя
        /// </summary>
        /// <param name="model">Модель запроса норма часов за период для пользователя</param>
        /// <returns></returns>
        public async Task<int> NormaHour(IShiftPersonalScheduleNormaHourModel model)
        {
            try
            {
                model.User.ThrowIfNull("User is null");
                model.DateStart.ThrowIfNull("DateStart is null");
                model.DateEnd.ThrowIfNull("DateEnd is null");

                var isExistUser = await _unitOfWork.AccountRepository.IsExistsAsync(model.User.Id);
                if (!isExistUser)
                {
                    var errorData = new ErrorData(ShiftPersonalScheduleErrors.UserNotFound, parameters : new object[] { model.User.Id });
                    throw new Exception(errorData.Message);
                }

                return _repository.GetScheduleShiftPersonalNormaHour(model.User.Id, model.DateStart, model.DateEnd);
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
        /// <returns></returns>
        private ValidationResult ValidateModel(IShiftPersonalScheduleUpdateModel model)
        {
            model.User.ThrowIfNull("User is null");
            model.Date.ThrowIfNull("Date is null");

            var shiftPersonalSchedules = model.ShiftPersonalSchedules ?? new List<IShiftPersonalScheduleModel>();

            var dates = shiftPersonalSchedules.Select(m => m.Date).Distinct();
            if (dates.Count() > 1)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionDateMoreOne);
            }

            if (dates.Any(d => d != model.Date))
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionDateMoreOne);
            }

            var users = shiftPersonalSchedules.Select(m => m.User.Id).Distinct();
            if (users.Count() > 1)
            {
                return new ValidationResult(ShiftPersonalScheduleErrors.CollectionUserMoreOne);
            }

            if (users.Any(id => id != model.User.Id))
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
        private async Task<ModelEntityModifyResult> UpdateInternal(IShiftPersonalScheduleUpdateModel model)
        {
            var shiftPersonalSchedules = model.ShiftPersonalSchedules ?? new List<IShiftPersonalScheduleModel>();

            //удаляем все то нет в списке
            var existSchedulers = _repository.GetByParam(model.User.Id, model.Date);
            foreach (var existScheduler in existSchedulers.ToList())
            {
                if (!shiftPersonalSchedules.Any(c => c.Date == existScheduler.Date && c.ShiftType.Id == existScheduler.ShiftTypeId))
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

                var resultModify = InsertOrUpdatePersonalSchedule(shiftPersonalScheduleModel);
                if (!resultModify.IsSucceeded)
                {
                    return resultModify;
                }                
            }

            _unitOfWork.Save();

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Обновление расписания смены для сотрудника
        /// </summary>
        /// <param name="shiftPersonalScheduleModel">Модель расписания смены соотрудника</param>
        private ModelEntityModifyResult InsertOrUpdatePersonalSchedule(IShiftPersonalScheduleModel shiftPersonalScheduleModel)
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

            var daoSchedule = _repository.GetByParam(shiftPersonalScheduleModel.User.Id, shiftPersonalScheduleModel.ShiftType.Id, shiftPersonalScheduleModel.Date);
            if (daoSchedule == null)
            {
                daoSchedule = CreateInternal(shiftPersonalScheduleModel);
                daoSchedule.ShiftPersonalSchedulePeriods = new List<ShiftPersonalSchedulePeriod>()
                {
                    CreatePersonalSchedulePeriod(daoSchedule, existUser.PlatformId.Value, existUser.PositionId)
                };

                _unitOfWork.ShiftPersonalScheduleRepository.Insert(daoSchedule);
            }
            else
            {
                DeleteAllWhereNotInLIst(shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods, daoSchedule.Id);

                if (shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods != null)
                {
                    foreach (var periodModel in shiftPersonalScheduleModel.ShiftPersonalSchedulePeriods)
                    {
                        InsertOrUpdatePeriod(daoSchedule.Id, periodModel);
                    }
                }
                else
                {
                    daoSchedule.ShiftPersonalSchedulePeriods = new List<ShiftPersonalSchedulePeriod>()
                    {
                        CreatePersonalSchedulePeriod(daoSchedule, existUser.PlatformId.Value, existUser.PositionId)
                    };
                }

                _unitOfWork.ShiftPersonalScheduleRepository.Update(daoSchedule);
            }             

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Удалим все, что нет в списке
        /// </summary>
        /// <param name="shiftPersonalSchedulePeriods">Список периодов</param>
        /// <param name="scheduleId">Id смены</param>
        private void DeleteAllWhereNotInLIst(ICollection<IShiftPersonalSchedulePeriodModel> shiftPersonalSchedulePeriods, int scheduleId)
        {
            if (shiftPersonalSchedulePeriods == null)
            {
                shiftPersonalSchedulePeriods = new List<IShiftPersonalSchedulePeriodModel>();
            }

            //удаляем период, если его нет в списке
            var existsPeriods = _unitOfWork.ShiftPersonalSchedulePeriodRepository.GetByShiftPersonalScheduleId(scheduleId);
            foreach (var existsPeriod in existsPeriods.ToList())
            {
                if (!shiftPersonalSchedulePeriods.Any(c => c.Id == existsPeriod.Id))
                {
                    _unitOfWork.ShiftPersonalSchedulePeriodRepository.Delete(existsPeriod);
                }
            }
        }

        /// <summary>
        /// Создать период
        /// </summary>
        /// <param name="daoSchedule">Смена в БД</param>
        /// <param name="platformId">Площадка</param>
        /// <param name="positionId">Должность</param>
        private ShiftPersonalSchedulePeriod CreatePersonalSchedulePeriod(ShiftPersonalSchedule daoSchedule, int platformId, int positionId)
        {
            var platform = _unitOfWork.PlatformRepository.GetById(platformId);
            if (platform == null)
            {
                throw new Exception(string.Format("Не найдена площадка с Id: {0}", platformId));
            }

            var existPeriod = _unitOfWork.ShiftPersonalRepository.Get(positionId, daoSchedule.ShiftTypeId, platform.IsAroundClock);
            if (existPeriod == null)
            {
                throw new Exception(string.Format("Для типа смены Id: {0}, должности: {1}, режим работы круглосуточно: {2} не задан режим работы!",
                    daoSchedule.ShiftTypeId, positionId, platform.IsAroundClock));
            }

            var period = new ShiftPersonalSchedulePeriod();
            period.ShiftPersonalScheduleId = daoSchedule.Id;
            period.StartTime = existPeriod.StartTime;
            period.StopTime = existPeriod.StopTime;
            return period;            
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
