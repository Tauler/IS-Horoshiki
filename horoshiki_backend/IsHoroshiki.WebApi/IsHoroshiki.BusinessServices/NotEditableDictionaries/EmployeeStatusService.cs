using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries.MappingDao;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Сервис Статус сотрудника
    /// </summary>
    public class EmployeeStatusService : BaseNotEditableDictionaryService<IEmployeeStatusModel>, IEmployeeStatusService
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
        public EmployeeStatusService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IEmployeeStatusService

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public override IEnumerable<IEmployeeStatusModel> GetAll()
        {
            return _unitOfWork.EmployeeStatusRepository.GetAll().ToModelEntityList();
        }

        #endregion
    }
}
