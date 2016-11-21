using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.MappingDao;
using IsHoroshiki.BusinessServices.NotEditable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using System.Threading.Tasks;
using System.Linq;

namespace IsHoroshiki.BusinessServices.NotEditable
{
    /// <summary>
    /// Сервис Отделы
    /// </summary>
    public class SubDepartmentService : BaseNotEditableService<ISubDepartmentModel, SubDepartment, ISubDepartmentRepository>, ISubDepartmentService
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
            : base(unitOfWork.SubDepartmentRepository)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region ISubDepartmentService

        /// <summary>
        /// Найти все подотделы для отдела
        /// </summary>
        /// <param name="departamentId">Id отдела</param>
        /// <returns></returns>
        public async Task<List<ISubDepartmentModel>> GetAllByDepartament(int departamentId)
        {
            var daoResult = await _repository.GetAllByDepartament(departamentId);
            return daoResult.ToModelEntityList().ToList();
        }

        #endregion

        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override ISubDepartmentModel ConvertTo(SubDepartment daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<ISubDepartmentModel> ConvertTo(IEnumerable<SubDepartment> collection)
        {
            return collection.ToModelEntityList();
        }

        #endregion
    }
}
