using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditable
{
    /// <summary>
    /// Сервис Статус площадки
    /// </summary>
    public class StatusSiteService : BaseNotEditableService<IStatusSiteModel, PlatformStatus>, IStatusSiteService
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
             : base(unitOfWork.StatusSiteRepository, null)
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
        protected override IStatusSiteModel ConvertTo(PlatformStatus daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IStatusSiteModel> ConvertTo(IEnumerable<PlatformStatus> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
