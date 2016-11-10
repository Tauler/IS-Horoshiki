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
            result.Position = null;
            result.ShiftType = null;
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
