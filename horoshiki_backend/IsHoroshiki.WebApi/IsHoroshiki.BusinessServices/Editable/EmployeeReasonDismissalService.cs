using System.Collections.Generic;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Статус сотрудника
    /// </summary>
    public class EmployeeReasonDismissalService : BaseEditableService<IEmployeeReasonDismissalModel, IEmployeeReasonDismissalValidator, EmployeeReasonDismissal, IEmployeeReasonDismissalRepository>, IEmployeeReasonDismissalService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public EmployeeReasonDismissalService(UnitOfWork unitOfWork, IEmployeeReasonDismissalValidator validator)
             : base(unitOfWork, unitOfWork.EmployeeReasonDismissalRepository, validator)
        {
           
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

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override EmployeeReasonDismissal CreateInternal(IEmployeeReasonDismissalModel model)
        {
            var result = model.ToDaoEntity();

            UpdateDaoInternal(result, model);

            return result;
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override EmployeeReasonDismissal UpdateDaoInternal(EmployeeReasonDismissal daoEntity, IEmployeeReasonDismissalModel model)
        {
            var result = daoEntity.Update(model);
            return result;
        }

        #endregion
    }
}
