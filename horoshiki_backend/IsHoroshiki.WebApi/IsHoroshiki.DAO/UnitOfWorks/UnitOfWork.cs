using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries;

namespace IsHoroshiki.DAO.UnitOfWorks
{
    /// <summary>  
    /// Unit of Work
    /// </summary>  
    public class UnitOfWork : IDisposable
    {
        #region поля и свойства

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Контекст выполнения БД
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Репозиторий Способы покупки
        /// </summary>
        private BuyProcessRepository _buyProcessPepository;

        /// <summary>
        /// Репозиторий Статус площадки
        /// </summary>
        private StatusSiteRepository _statusSiteRepository;
        
        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region свойства репозиториев

        /// <summary>  
        /// Репозиторий Способы покупки  
        /// </summary>  
        public BuyProcessRepository BuyProcessPepository
        {
            get
            {
                if (this._buyProcessPepository == null)
                {
                    this._buyProcessPepository = new BuyProcessRepository(_context);
                }
                return _buyProcessPepository;
            }
        }

        /// <summary>  
        /// Репозиторий Статус площадки  
        /// </summary>  
        public StatusSiteRepository StatusSiteRepository
        {
            get
            {
                if (this._statusSiteRepository == null)
                {
                    this._statusSiteRepository = new StatusSiteRepository(_context);
                }
                return _statusSiteRepository;
            }
        }

        #endregion

        #region методы

        /// <summary>  
        /// Сохранить контекст  
        /// </summary>  
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

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
                _context.Dispose();
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
