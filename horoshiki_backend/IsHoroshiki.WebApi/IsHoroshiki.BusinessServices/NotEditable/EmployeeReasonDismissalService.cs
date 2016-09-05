using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessServices.NotEditable
{
    /// <summary>
    /// Сервис Статус сотрудника
    /// </summary>
    public class EmployeeReasonDismissalService : BaseNotEditableService<IEmployeeReasonDismissalModel, EmployeeReasonDismissal, IEmployeeReasonDismissalRepository>, IEmployeeReasonDismissalService
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
        public EmployeeReasonDismissalService(UnitOfWork unitOfWork)
             : base(unitOfWork.EmployeeReasonDismissalRepository)
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
        protected override IEmployeeReasonDismissalModel ConvertTo(EmployeeReasonDismissal daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IEmployeeReasonDismissalModel> ConvertTo(IEnumerable<EmployeeReasonDismissal> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
