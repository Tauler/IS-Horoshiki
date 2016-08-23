using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Время доставки
    /// </summary>
    public class DeliveryTimeService : BaseNotEditableDictionaryService<IDeliveryTimeModel>, IDeliveryTimeService
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
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IDeliveryTimeService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IDeliveryTimeModel> GetAll()
        {
            return _unitOfWork.DeliveryTimeRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
