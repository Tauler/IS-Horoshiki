using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using IsHoroshiki.DAO;
using IsHoroshiki.DAO.Repositories;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый сервис не редактируемого типа
    /// </summary>
    public abstract class BaseNotEditableService<TModelEntity, TDaoEntity, TDaoEntityRepository> : BaseBusinessService<TModelEntity, TDaoEntity>, IBaseNotEditableService<TModelEntity>
        where TModelEntity : class, IBaseNotEditableModel
        where TDaoEntity : BaseDaoEntity
        where TDaoEntityRepository : class, IBaseRepository<TDaoEntity>
    {
        #region поля и свойства

        /// <summary>
        /// Репозитарий сущности
        /// </summary>
        protected TDaoEntityRepository _repository;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository">Репозитарий сущности</param>
        protected BaseNotEditableService(TDaoEntityRepository repository)
            : base(repository)
        {
            _repository = repository;
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
