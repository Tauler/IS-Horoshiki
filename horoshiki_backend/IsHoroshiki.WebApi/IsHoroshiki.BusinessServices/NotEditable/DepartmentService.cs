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
    /// Сервис Отделы
    /// </summary>
    public class DepartmentService : BaseNotEditableService<IDepartmentModel, Department>, IDepartmentService
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
        public DepartmentService(UnitOfWork unitOfWork)
            : base(unitOfWork.DepartmentRepository, null)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected override IDepartmentModel ConvertTo(Department daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IDepartmentModel> ConvertTo(IEnumerable<Department> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
