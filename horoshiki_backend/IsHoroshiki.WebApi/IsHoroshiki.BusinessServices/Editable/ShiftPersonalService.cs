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

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Смена
    /// </summary>
    public class ShiftPersonalService : BaseEditableService<IShiftPersonalModel, IShiftPersonalValidator, ShiftPersonal, IShiftPersonalRepository>, IShiftPersonalService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="validator">Валидатор</param>
        public ShiftPersonalService(UnitOfWork unitOfWork, IShiftPersonalValidator validator)
            : base(unitOfWork, unitOfWork.ShiftPersonalRepository, validator)
        {
        }

        #endregion

        #region IShiftPersonalService

        public async Task<IShiftPersonalTableModel> GetTable()
        {
            return CreateDefaultTable();
        }

        /// <summary>
        /// Сохранение рабочего интервала времени
        /// </summary>
        /// <param name="model">Смена</param>
        /// <returns></returns>
        public async Task<ModelEntityModifyResult> UpdateWorkingTime(IShiftPersonalModel model)
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

        #region private

        private IShiftPersonalTableModel CreateDefaultTable()
        {
            var table = new ShiftPersonalTableModel();

            var positions = _unitOfWork.PositionRepository.GetPositionsOnShiftAsync().Result;
            var shiftTypes = _unitOfWork.ShiftTypeRepository.GetAllAsync().Result;

            var dataRows = new List<IShiftPersonalDataRowModel>();

            foreach (var position in positions)
            {
                var dataRow = new ShiftPersonalDataRowModel();
                dataRow.Position = position.Value;

                var shiftTimes = new List<IShiftPersonalShiftTimeModel>();

                foreach (var shiftType in shiftTypes)
                {
                    var shiftPersonal = CreateOrUpdate(position, shiftType);

                    var shiftTime = new ShiftPersonalShiftTimeModel
                    {
                        ShiftPart = new ShiftPersonalShiftPartModel
                        {
                            Name = shiftPersonal.ShiftType.Value,
                            ShortName = shiftPersonal.ShiftType.Socr
                        },
                        TimePart = new ShiftPersonalTimePartModel
                        {
                            Id = shiftPersonal.Id,
                            TimeStart = shiftPersonal.StartTime,
                            TimeEnd = shiftPersonal.StopTime
                        }
                    };

                    shiftTimes.Add(shiftTime);
                }
                dataRow.ShiftTime = shiftTimes;

                dataRows.Add(dataRow);
            }

            table.DataRows = dataRows;
            return table;
        }

        private ShiftPersonal CreateOrUpdate(Position position, ShiftType shiftType)
        {
            var shiftPersonal = _unitOfWork.ShiftPersonalRepository.Get(position.Id, shiftType.Id);
            if (shiftPersonal == null)
            {
                shiftPersonal = new ShiftPersonal() {
                    Position = position,
                    PositionId = position.Id,
                    ShiftType = shiftType,
                    ShiftTypeId = shiftType.Id,
                    IsAroundClock = false,
                    StartTime = TimeSpan.FromHours(8),
                    StopTime = TimeSpan.FromHours(1)
                };
                _unitOfWork.ShiftPersonalRepository.Insert(shiftPersonal);
                _unitOfWork.Save();
                shiftPersonal = _unitOfWork.ShiftPersonalRepository.Get(position.Id, shiftType.Id);
            }
            return shiftPersonal;
        }

        #endregion
    }
}
