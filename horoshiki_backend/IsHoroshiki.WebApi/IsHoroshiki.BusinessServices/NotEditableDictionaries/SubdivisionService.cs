using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Подразделения
    /// </summary>
    public class SubdivisionService : BaseNotEditableDictionaryService<ISubdivisionModel>, ISubdivisionService
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
        public SubdivisionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region ISubdivisioneService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<ISubdivisionModel> GetAll()
        {
            return _unitOfWork.SubdivisionRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
