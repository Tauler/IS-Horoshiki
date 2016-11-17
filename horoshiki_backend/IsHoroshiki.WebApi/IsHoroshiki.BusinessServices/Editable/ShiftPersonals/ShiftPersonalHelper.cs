using IsHoroshiki.BusinessEntities.Editable.ShiftPersonals;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonals
{
    /// <summary>
    /// Создает результатирующую таблицу с настройками смен работы
    /// </summary>
    public class ShiftPersonalHelper : IShiftPersonalHelper
    {
        #region Поля и свойства

        /// <summary>
        /// Единица работы
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">Единица работы</param>
        public ShiftPersonalHelper(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region IShiftPersonalHelper

        /// <summary>
        /// Создать результатирующую таблицу с настройками смен работы
        /// </summary>
        /// <returns></returns>
        public IShiftPersonalTableModel CreateDefaultTable()
        {
            var positions = _unitOfWork.PositionRepository.GetPositionsOnShiftAsync().Result;
            var shiftTypes = _unitOfWork.ShiftTypeRepository.GetAllAsync().Result;

            var dataRows = new List<IShiftPersonalDataRowModel>();
            foreach (var position in positions)
            {
                dataRows.Add(CreateDataRow(position, shiftTypes));
            }

            return new ShiftPersonalTableModel
            {
                DataRows = dataRows
            };
        }

        #endregion

        #region private

        /// <summary>
        /// Создать строку результатирующей таблицы с настройками смены работы
        /// </summary>
        /// <param name="position"></param>
        /// <param name="shiftTypes"></param>
        /// <returns></returns>
        private IShiftPersonalDataRowModel CreateDataRow(Position position, IEnumerable<ShiftType> shiftTypes)
        {
            var shiftTimes = new List<IShiftPersonalShiftTimeModel>();
            foreach (var shiftType in shiftTypes)
            {
                shiftTimes.Add(CreateShiftTimeModel(CreateOrUpdate(position, shiftType, false)));
                shiftTimes.Add(CreateShiftTimeModel(CreateOrUpdate(position, shiftType, true)));
            }
            return new ShiftPersonalDataRowModel
            {
                Position = position.Value,
                ShiftTimes = shiftTimes
            };
        }

        /// <summary>
        /// Для строки таблицы создать настройки смен работы для каждого типа смены и признака "Круглосуточно"
        /// </summary>
        /// <param name="shiftPersonal"></param>
        /// <returns></returns>
        private IShiftPersonalShiftTimeModel CreateShiftTimeModel(ShiftPersonal shiftPersonal)
        {
            return new ShiftPersonalShiftTimeModel
            {
                IsAroundClock = shiftPersonal.IsAroundClock,
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
        }

        /// <summary>
        /// Сохнанить новую или загрузить существующую настройку смены работы в/из БД
        /// </summary>
        /// <param name="position"></param>
        /// <param name="shiftType"></param>
        /// <param name="isAroundClock"></param>
        /// <returns></returns>
        private ShiftPersonal CreateOrUpdate(Position position, ShiftType shiftType, bool isAroundClock)
        {
            var shiftPersonal = _unitOfWork.ShiftPersonalRepository.Get(position.Id, shiftType.Id, isAroundClock);
            if (shiftPersonal == null)
            {
                shiftPersonal = new ShiftPersonal()
                {
                    Position = position,
                    PositionId = position.Id,
                    ShiftType = shiftType,
                    ShiftTypeId = shiftType.Id,
                    IsAroundClock = isAroundClock,
                    StartTime = isAroundClock ? TimeSpan.Zero : TimeSpan.FromHours(8),
                    StopTime = isAroundClock ? TimeSpan.Zero : TimeSpan.FromHours(1)
                };
                _unitOfWork.ShiftPersonalRepository.Insert(shiftPersonal);
                _unitOfWork.Save();
                shiftPersonal = _unitOfWork.ShiftPersonalRepository.Get(position.Id, shiftType.Id, isAroundClock);
            }
            return shiftPersonal;
        }

        #endregion
    }
}
