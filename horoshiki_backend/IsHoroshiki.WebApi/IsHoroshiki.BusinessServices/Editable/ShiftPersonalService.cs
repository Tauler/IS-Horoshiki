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
using System.Collections;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Editable.ShiftPersonals;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Смена
    /// </summary>
    public class ShiftPersonalService : BaseEditableService<IShiftPersonalModel, IShiftPersonalValidator, ShiftPersonal, IShiftPersonalRepository>, IShiftPersonalService
    {
        #region Поля и свойства

        /// <summary>
        /// Создает результатирующую таблицу с настройками смен работы
        /// </summary>
        private readonly IShiftPersonalHelper _shiftPersonalHelper;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="validator">Валидатор</param>
        public ShiftPersonalService(UnitOfWork unitOfWork, IShiftPersonalValidator validator, IShiftPersonalHelper shiftPersonalHelper)
            : base(unitOfWork, unitOfWork.ShiftPersonalRepository, validator)
        {
            this._shiftPersonalHelper = shiftPersonalHelper;
        }

        #endregion

        #region IShiftPersonalService

        /// <summary>
        /// Создать результатирующую таблицу с настройками смен работы
        /// </summary>
        /// <returns></returns>
        public async Task<IShiftPersonalTableModel> GetTable()
        {
            return _shiftPersonalHelper.CreateDefaultTable();
        }

        /// <summary>
        /// Сохранение рабочего интервала времени
        /// </summary>
        /// <param name="model">Изменяемая часть смены</param>
        /// <returns></returns>
        public async Task<ModelEntityModifyResult> UpdateWorkingTime(IShiftPersonalTimePartModel model)
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

            daoEntity.StartTime = model.TimeStart;
            daoEntity.StopTime = model.TimeEnd;

            _repository.Update(daoEntity);
            _unitOfWork.Save();

            return new ModelEntityModifyResult();
        }

        #endregion

        #region override

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonal CreateInternal(IShiftPersonalModel model)
        {
            return model.ToDaoEntity();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override ShiftPersonal UpdateDaoInternal(ShiftPersonal daoEntity, IShiftPersonalModel model)
        {
            var result = daoEntity.Update(model);
            result.Position = _unitOfWork.PositionRepository.GetByIdAsync(result.PositionId).Result;
            result.ShiftType = _unitOfWork.ShiftTypeRepository.GetByIdAsync(result.ShiftTypeId).Result;
            return result;
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IShiftPersonalModel> ConvertTo(IEnumerable<ShiftPersonal> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IShiftPersonalModel ConvertTo(ShiftPersonal daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        #endregion
    }
}
