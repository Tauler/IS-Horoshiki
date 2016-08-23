using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Отделы
    /// </summary>
    public class SubDepartmentService : BaseNotEditableDictionaryService<ISubDepartmentModel>, ISubDepartmentService
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
        public SubDepartmentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IDepartmentService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<ISubDepartmentModel> GetAll()
        {
            return _unitOfWork.SubDepartmentRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
