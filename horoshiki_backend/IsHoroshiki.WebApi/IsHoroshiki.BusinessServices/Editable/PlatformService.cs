using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Платформа
    /// </summary>
    public class PlatformService : BaseEditableService<IPlatformModel, IPlatformValidator, Platform, IPlatformRepository>, IPlatformService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public PlatformService(UnitOfWork unitOfWork, IPlatformValidator validator)
            : base(unitOfWork, unitOfWork.PlatformRepository, validator)
        {
            
        }

        #endregion

        #region protected override

        /// <summary>
        /// Получить всех
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public override async Task<PagedResult<IPlatformModel>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            if (string.Equals(sortField, "SubDivisionModel") 
                || string.Equals(sortField, "UserModel")
                || string.Equals(sortField, "PlatformStatusModel"))
            {
                sortField += "Id";
            }
            
            return await base.GetAllAsync(pageNo, pageSize, sortField, isAscending);
        }

        /// <summary>
        /// true - если можно удалить из БД
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        public override async Task<bool> IsCanDeleteAsync(int id)
        {
            return true;
        }

        /// <summary>
        /// Валидация сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        protected override async Task<ValidationResult> ValidationInternal(IPlatformModel model)
        {
            var result = await IsExistDaoEntity(_unitOfWork.PlatformStatusRepository, model.PlatformStatusModel);
            if (!result)
            {
                return new ValidationResult(PlatformErrors.PlatformStatusNotFound, model.PlatformStatusModel?.Id ?? 0);
            }

            result = await IsExistDaoEntity(_unitOfWork.SubDivisionRepository, model.SubDivisionModel);
            if (!result)
            {
                return new ValidationResult(PlatformErrors.SubDivisionNotFound, model.SubDivisionModel?.Id ?? 0);
            }

            if (model.UserModel != null && model.UserModel.Id > 0)
            {
                var user = await _unitOfWork.AccountRepository.GetByIdAsync(model.UserModel.Id);
                if (user == null)
                {
                    return new ValidationResult(PlatformErrors.UserNotFound, (int) model.UserModel?.Id);
                }
            }

            if (model.BuyProcessesModel != null)
            {
                foreach (var buyProcessModel in model.BuyProcessesModel)
                {
                    result = await IsExistDaoEntity(_unitOfWork.BuyProcessPepository, buyProcessModel);
                    if (!result)
                    {
                        return new ValidationResult(PlatformErrors.BuyProcessNotFound, buyProcessModel?.Id ?? 0);
                    }
                }
            }

            return new ValidationResult();
        }

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IPlatformModel ConvertTo(Platform daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IPlatformModel> ConvertTo(IEnumerable<Platform> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override Platform CreateInternal(IPlatformModel model)
        {
            return model.ToDaoEntity();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override Platform UpdateDaoInternal(Platform daoEntity, IPlatformModel model)
        {
            var result = daoEntity.Update(model);
            result.User = null;
            result.PlatformStatus = null;
            result.SubDivision = null;
            return result;
        }

        #endregion
    }
}
