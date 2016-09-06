using System;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.DAO;
using IsHoroshiki.DAO.Repositories;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис для редактируемого типа
    /// </summary>
    public abstract class BaseEditableService<TModelEntity, TModelEntityValidator, TDaoEntity, TDaoEntityRepository> : BaseBusinessService<TModelEntity, TDaoEntity>, IBaseEditableService<TModelEntity>
       where TModelEntity : class, IBaseBusninessModel
       where TModelEntityValidator : class, IValidator<TModelEntity>
       where TDaoEntity : class, IBaseDaoEntity
       where TDaoEntityRepository : class, IBaseRepository<TDaoEntity>
    {
        #region поля и свойства

        /// <summary>
        /// UnitOfWork
        /// </summary>
        protected readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Валидатор сущности
        /// </summary>
        protected readonly TModelEntityValidator _validator;

        /// <summary>
        /// Репозитарий сущности
        /// </summary>
        protected readonly TDaoEntityRepository _repository;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="repository">Репозитарий сущности</param>
        /// <param name="validator">Валидатор сущности</param>
        protected BaseEditableService(UnitOfWork unitOfWork, TDaoEntityRepository repository, TModelEntityValidator validator)
            : base(repository)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            _unitOfWork = unitOfWork;
            _repository = repository;
            _validator = validator;
        }

        #endregion

        #region IBaseEditableService

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
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
                if (model == null)
                {
                    return new ModelEntityModifyResult(CommonErrors.EntityAddIsNull);
                }

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
                _unitOfWork.Save();

                return new ModelEntityModifyResult(daoEntity.Id);
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                return new ModelEntityModifyResult(errorData);
            }
        }

        /// <summary>
        /// ОБновить в БД
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public virtual async Task<ModelEntityModifyResult> UpdateAsync(TModelEntity model)
        {
            try
            {
                if (model == null)
                {
                    return new ModelEntityModifyResult(CommonErrors.Exception);
                }

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
                    var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { model.Id});
                    return new ModelEntityModifyResult(errorData); 
                }

                UpdateDaoInternal(daoEntity, model);

                _repository.Update(daoEntity);
                _unitOfWork.Save();

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                return new ModelEntityModifyResult(errorData);
            }
        }

        /// <summary>
        /// true - если можно удалить из БД
        /// </summary>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        public abstract Task<bool> IsCanDeleteAsync(int id);

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
                    var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { id });
                    return new ModelEntityModifyResult(errorData);
                }

                 _repository.Delete(id);

                _unitOfWork.Save();

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                return new ModelEntityModifyResult(errorData);
            }
        }

        #endregion

        #region virtual

        /// <summary>
        /// Валидация сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        protected virtual async Task<ValidationResult> ValidationInternal(TModelEntity model)
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
        public abstract TDaoEntity UpdateDaoInternal(TDaoEntity daoEntity, TModelEntity model);

        #endregion

        #region IDisposable 

        /// <summary>  
        /// IDisposable
        /// </summary>  
        /// <param name="disposing"></param>  
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _unitOfWork.Dispose();
            }
            this._disposed = true;
        }

        #endregion
    }
}
