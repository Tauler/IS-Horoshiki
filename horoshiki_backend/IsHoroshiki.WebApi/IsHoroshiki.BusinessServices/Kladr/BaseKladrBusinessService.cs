using IsHoroshiki.DAO.Kladr;
using IsHoroshiki.DAO.UnitOfWorks;
using System;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Базовый класс сервисов кладр
    /// </summary>
    public abstract class BaseKladrBusinessService<TDaoEntity, TDaoEntityRepository> : IBaseKladrBusinessService<TDaoEntity> 
        where TDaoEntity : IBaseDaoEntity
        where TDaoEntityRepository : class, IBaseRepository<TDaoEntity>
    {
        #region поля и свойства 

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        protected bool _disposed;

        /// <summary>
        /// UnitOfWork
        /// </summary>
        protected readonly KladrUnitOfWork _unitOfWork;

        /// <summary>
        /// Репозитарий сущности
        /// </summary>
        private readonly TDaoEntityRepository _repository;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="repository">Репозитарий сущности</param>
        protected BaseKladrBusinessService(KladrUnitOfWork unitOfWork, TDaoEntityRepository repository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            if (repository == null)
            {
                throw new ArgumentNullException();
            }

            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion

        #region IDisposable 

        /// <summary>  
        /// IDisposable
        /// </summary>  
        /// <param name="disposing"></param>  
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _unitOfWork.Dispose();
            }
            this._disposed = true;
        }

        /// <summary>  
        /// Dispose  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
