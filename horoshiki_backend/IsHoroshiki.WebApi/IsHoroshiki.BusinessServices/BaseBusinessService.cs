using System;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices
{
    /// <summary>
    /// Базовый класс для всей бизнес-логики сервисов
    /// </summary>
    public abstract class BaseBusinessService : IBaseBusinessService
    {
        #region поля и свойства 

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// UnitOfWork
        /// </summary>
        protected readonly UnitOfWork _unitOfWork = new UnitOfWork();

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
