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
    /// Сервис Статус сотрудника
    /// </summary>
    public class EmployeeStatusService : BaseNotEditableService<IEmployeeStatusModel, EmployeeStatus>, IEmployeeStatusService
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
             : base(unitOfWork.EmployeeStatusRepository, null)
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
        protected override IEmployeeStatusModel ConvertTo(EmployeeStatus daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IEmployeeStatusModel> ConvertTo(IEnumerable<EmployeeStatus> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
