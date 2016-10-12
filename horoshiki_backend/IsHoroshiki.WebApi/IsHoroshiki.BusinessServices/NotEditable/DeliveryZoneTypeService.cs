using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessServices.NotEditable
{
    /// <summary>
    /// Сервис Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeService : BaseNotEditableService<IDeliveryZoneTypeModel, DeliveryZoneType, IDeliveryZoneTypeRepository>, IDeliveryZoneTypeService
    {
        #region поля и свойства

        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        public DeliveryZoneTypeService(UnitOfWork unitOfWork)
            : base(unitOfWork.DeliveryZoneTypeRepository)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IDeliveryZoneTypeModel ConvertTo(DeliveryZoneType daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IDeliveryZoneTypeModel> ConvertTo(IEnumerable<DeliveryZoneType> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
