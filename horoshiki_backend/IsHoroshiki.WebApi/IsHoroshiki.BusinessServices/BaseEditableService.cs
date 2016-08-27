using System;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.DAO;
using IsHoroshiki.DAO.Repositories;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис для редактируемого типа
    /// </summary>
    public abstract class BaseEditableService<TModelEntity, TDaoEntity> : BaseBusinessService<TModelEntity, TDaoEntity>, IBaseEditableService<TModelEntity>
       where TModelEntity : class, IBaseBusninessModel
       where TDaoEntity : BaseDaoEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository">Репозитарий сущности</param>
        /// <param name="validator">Валидатор сущности</param>
        protected BaseEditableService(IBaseRepository<TDaoEntity> repository, IValidator<TModelEntity> validator)
            : base(repository, validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

        #region IBaseEditableService

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <returns></returns>  
        public virtual async Task<PagedResult<TModelEntity>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            var count = await _repository.CountAsync();
            var list = await _repository.GetAllAsync(pageNo, pageSize, sortField, isAscending);
            var result = ConvertTo(list);
            return new PagedResult<TModelEntity>(result, pageNo, pageSize, count);
        }

        /// <summary>
        /// Добавить в БД
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public virtual async Task<ModelEntityModifyResult> AddAsync(TModelEntity model)
        {
            try
            {
                var validateResult = await _validator.ValidateAsync(model);
                if (!validateResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(validateResult.Errors);
                }

                var customValidateResult = await ValidationInternal(model);
                if (!customValidateResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(customValidateResult.Errors);
                }

                var daoEntity = CreateInternal(model);

                _repository.Insert(daoEntity);

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                return new ModelEntityModifyResult(e.Message);
            }
        }

        /// <summary>
        /// Добавить в БД
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public virtual async Task<ModelEntityModifyResult> UpdateAsync(TModelEntity model)
        {
            try
            {
                var validateResult = await _validator.ValidateAsync(model);
                if (!validateResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(validateResult.Errors);
                }

                var customValidateResult = await ValidationInternal(model);
                if (!customValidateResult.IsSucceeded)
                {
                    return new ModelEntityModifyResult(customValidateResult.Errors);
                }

                var daoEntity = await _repository.GetByIdAsync(model.Id);
                if (daoEntity == null)
                {
                    return new ModelEntityModifyResult($"Объекта с Id={model.Id} не существует!"); 
                }

                UpdateInternal(daoEntity, model);
                
                _repository.Update(daoEntity);

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                return new ModelEntityModifyResult(e.Message);
            }
        }

        /// <summary>
        /// Удалить из БД
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        public virtual async Task<ModelEntityModifyResult> DeleteAsync(int id)
        {
            try
            {
                var daoEntity = await _repository.GetByIdAsync(id);
                if (daoEntity == null)
                {
                    return new ModelEntityModifyResult($"Объекта с Id={id} не существует!");
                }

                 _repository.Delete(id);

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                return new ModelEntityModifyResult(e.Message);
            }
        }

        #endregion

        #region virtual

        /// <summary>
        /// Валидация сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        protected async virtual Task<ValidationResult> ValidationInternal(TModelEntity model)
        {
            return new ValidationResult();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public abstract TDaoEntity CreateInternal(TModelEntity model);

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <param name="daoEntity">dao Сущность</param>
        /// <returns></returns>
        public abstract TDaoEntity UpdateInternal(TDaoEntity daoEntity, TModelEntity model);

        #endregion
    }
}
