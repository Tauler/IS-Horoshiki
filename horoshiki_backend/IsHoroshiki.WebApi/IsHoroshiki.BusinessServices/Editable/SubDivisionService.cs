using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Подразделения
    /// </summary>
    public class SubDivisionService : BaseEditableService<SubDivisionModel, SubDivision>, ISubDivisionService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public SubDivisionService(UnitOfWork unitOfWork, ISubDivisionValidator validator)
            : base(unitOfWork, unitOfWork.SubDivisionRepository, validator)
        {
            
        }

        #endregion

        #region protected override

        /// <summary>
        /// Валидация сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        protected async override Task<ValidationResult> ValidationInternal(SubDivisionModel model)
        {
            if (model.PriceTypeModel != null)
            {
                var daoPriceType = await _unitOfWork.PriceTypeRepository.GetByIdAsync(model.PriceTypeModel.Id);
                if (daoPriceType == null)
                {
                    return new ValidationResult(string.Format(ResourceBusinessServices.SubDivisionService_PriceTypeNotFound, model.PriceTypeModel.Id));
                }
            }

            return new ValidationResult();
        }

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override SubDivisionModel ConvertTo(SubDivision daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<SubDivisionModel> ConvertTo(IEnumerable<SubDivision> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SubDivision CreateInternal(SubDivisionModel model)
        {
            return model.ToDaoEntity();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SubDivision UpdateDaoInternal(SubDivision daoEntity, SubDivisionModel model)
        {
            return daoEntity.Update(model);
        }

        #endregion
    }
}
