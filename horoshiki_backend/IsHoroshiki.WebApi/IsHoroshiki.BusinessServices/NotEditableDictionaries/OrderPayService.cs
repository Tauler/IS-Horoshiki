using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Оплата заказа
    /// </summary>
    public class OrderPayService : BaseNotEditableDictionaryService<IOrderPayModel>, IOrderPayService
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
        public OrderPayService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IOrderSettingService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IOrderPayModel> GetAll()
        {
            return _unitOfWork.OrderPayRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
