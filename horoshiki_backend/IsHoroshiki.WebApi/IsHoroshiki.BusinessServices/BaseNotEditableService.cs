using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.DAO;
using IsHoroshiki.DAO.Repositories;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис не редактируемого типа
    /// </summary>
    public abstract class BaseNotEditableService<TModelEntity, TDaoEntity> : BaseBusinessService<TModelEntity, TDaoEntity>, IBaseNotEditableService<TModelEntity>
        where TModelEntity : class, IBaseNotEditableModel
        where TDaoEntity : BaseDaoEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository">Репозитарий сущности</param>
        /// <param name="validator">Валидатор сущности</param>
        protected BaseNotEditableService(IBaseRepository<TDaoEntity> repository, IValidator<TModelEntity> validator)
            : base(repository, validator)
        {
            
        }

        #endregion

        #region IBaseNotEditableService

        /// <summary>  
        /// Получить все записи
        /// </summary>  
        /// <returns></returns>  
        public virtual async Task<IEnumerable<TModelEntity>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync(1, Int32.MaxValue);
            return ConvertTo(list);
        }

        #endregion
    }
}
