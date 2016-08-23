using System;

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
        protected bool _disposed;

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
