using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Типы зон доставки
    /// </summary>
    public class DeliveryZoneService : BaseNotEditableDictionaryService<IDeliveryZoneModel>, IDeliveryZoneService
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
        public DeliveryZoneService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IDeliveryZoneService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IDeliveryZoneModel> GetAll()
        {
            return _unitOfWork.DeliveryZoneRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
