using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Зона доставки
    /// </summary>
    public class DeliveryZoneService : BaseEditableService<IDeliveryZoneModel, IDeliveryZoneValidator, DeliveryZone, IDeliveryZoneRepository>, IDeliveryZoneService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public DeliveryZoneService(UnitOfWork unitOfWork, IDeliveryZoneValidator validator)
             : base(unitOfWork, unitOfWork.DeliveryZoneRepository, validator)
        {
           
        }

        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IDeliveryZoneModel ConvertTo(DeliveryZone daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IDeliveryZoneModel> ConvertTo(IEnumerable<DeliveryZone> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override DeliveryZone CreateInternal(IDeliveryZoneModel model)
        {
            var result = model.ToDaoEntity();

            UpdateDaoInternal(result, model);

            return result;
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override DeliveryZone UpdateDaoInternal(DeliveryZone daoEntity, IDeliveryZoneModel model)
        {
            var result = daoEntity.Update(model);

            if (result.DeliveryZoneTypeId > 0)
            {
                result.DeliveryZoneType = _unitOfWork.DeliveryZoneTypeRepository.GetByIdAsync(result.DeliveryZoneTypeId).Result;
            }

            if (result.PlatformId > 0)
            {
                result.Platform = _unitOfWork.PlatformRepository.GetByIdAsync(result.PlatformId).Result;
            }

            return result;
        }

        #endregion
    }
}
