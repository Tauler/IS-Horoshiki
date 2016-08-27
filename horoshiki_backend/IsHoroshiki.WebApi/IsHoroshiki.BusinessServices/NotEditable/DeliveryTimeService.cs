using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditable
{
    /// <summary>
    /// Сервис Время доставки
    /// </summary>
    public class DeliveryTimeService : BaseNotEditableService<IDeliveryTimeModel, DeliveryTime>, IDeliveryTimeService
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
        public DeliveryTimeService(UnitOfWork unitOfWork)
             : base(unitOfWork.DeliveryTimeRepository, null)
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
        protected override IDeliveryTimeModel ConvertTo(DeliveryTime daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IDeliveryTimeModel> ConvertTo(IEnumerable<DeliveryTime> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
