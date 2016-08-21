using System;
using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Способы покупки
    /// </summary>
    public class BuyProcessService : BaseNotEditableDictionaryService<IBuyProcessModel>, IBuyProcessService
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
        public BuyProcessService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IBuyProcessService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IBuyProcessModel> GetAll()
        {
            return _unitOfWork.BuyProcessPepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
