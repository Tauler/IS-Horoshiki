using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Статус площадки
    /// </summary>
    public class StatusSiteService : BaseNotEditableDictionaryService<IStatusSiteModel>, IStatusSiteService
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
        public StatusSiteService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IStatusSiteService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IStatusSiteModel> GetAll()
        {
            return _unitOfWork.StatusSiteRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
