using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using IsHoroshiki.BusinessServices.Editable.MonthObjectives;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Цель на месяц
    /// </summary>
    public class MonthObjectiveService : BaseEditableService<IMonthObjectiveModel, IMonthObjectiveValidator, MonthObjective, IMonthObjectiveRepository>, IMonthObjectiveService
    {

        /// <summary>
        /// Хелпер построения целей на месяц
        /// </summary>
        private readonly IMonthObjectiveHelper _monthObjectiveHelper;

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="validator">Валидатор</param>
        public MonthObjectiveService(UnitOfWork unitOfWork, IMonthObjectiveValidator validator, IMonthObjectiveHelper monthObjectiveHelper)
            : base(unitOfWork, unitOfWork.MonthObjectiveRepository, validator)
        {
            this._monthObjectiveHelper = monthObjectiveHelper;
        }

        #endregion

        #region IMonthObjectiveService

        /// <summary>
        /// Создать цель на месяц
        /// </summary>
        public async Task<IMonthObjectiveModel> Add(IMonthObjectiveModel model)
        {
            if (model == null)
            {
                return null;
            }

            var validateResult = await _validator.ValidateAsync(model);
            if (!validateResult.IsSucceeded)
            {
                throw new Exception(validateResult.Errors.First().Message);
            }

            ThrowIfPlatformNotExist(model.Platform.Id);

            return await this._monthObjectiveHelper.Get(model);
        }

        /// <summary>
        /// Редактировать показатели цели на месяц
        /// </summary>
        public async Task<ModelEntityModifyResult> UpdateChecksPerHourForPosition(IMonthObjectiveModel model)
        {
            if (model == null)
            {
                return new ModelEntityModifyResult(CommonErrors.EntityUpdateIsNull);
            }

            var daoEntity = await _repository.GetByIdAsync(model.Id);
            if (daoEntity == null)
            {
                var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { model.Id });
                return new ModelEntityModifyResult(errorData);
            }

            daoEntity.ChecksPerHourForPositionSushiChef = model.ChecksPerHourForPositionSushiChef;
            daoEntity.ChecksPerHourForPositionCourier = model.ChecksPerHourForPositionCourier;
            daoEntity.ChecksPerHourForPositionPizzaChef = model.ChecksPerHourForPositionPizzaChef;

            this._repository.Update(daoEntity);
            this._unitOfWork.Save();

            return new ModelEntityModifyResult();
        }

        #endregion

        #region override

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override MonthObjective CreateInternal(IMonthObjectiveModel model)
        {
            return model.ToDaoEntity();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override MonthObjective UpdateDaoInternal(MonthObjective daoEntity, IMonthObjectiveModel model)
        {
            var result = daoEntity.Update(model);
            result.Platform = _unitOfWork.PlatformRepository.GetByIdAsync(result.PlatformId).Result;
            return result;
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IMonthObjectiveModel> ConvertTo(IEnumerable<MonthObjective> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IMonthObjectiveModel ConvertTo(MonthObjective daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        #endregion

        /// <summary>
        /// Вбросить экспешн, если не существует площадки
        /// </summary>
        /// <param name="platformId">Id площадки</param>
        private async void ThrowIfPlatformNotExist(int platformId)
        {
            var plaformIsExist = await _unitOfWork.PlatformRepository.IsExistsAsync(platformId);
            if (!plaformIsExist)
            {
                var errorData = new ErrorData(MonthObjectiveErrors.PlatformIsNull);
                throw new Exception(errorData.Message);
            }
        }
    }
}
