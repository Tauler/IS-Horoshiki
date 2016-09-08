using System;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.Kladr.Repositories;

namespace IsHoroshiki.DAO.UnitOfWorks
{
    /// <summary>  
    /// Unit of Work
    /// </summary>  
    public class KladrUnitOfWork : IDisposable
    {
        #region поля и свойства

        /// <summary>
        /// true - если был вызван Dispose
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Контекст выполнения БД
        /// </summary>
        private readonly KladrDbContext _context;

        /// <summary>
        /// Репозитарий Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов
        /// </summary>
        private IAltNameRepository _altNameRepository;

        /// <summary>
        /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
        /// </summary>
        private IDomaRepository _domaRepository;

        /// <summary>
        ///Репозитарий Записи с объектами седьмого уровня классификации (номера квартир домов);
        /// </summary>
        private IFlatRepository _flatRepository;

        /// <summary>
        /// Репозитарий Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
        /// </summary>
        private IKladrRepository _kladrRepository;

        /// <summary>
        /// Репозитарий Записи с краткими наименованиями типов адресных объектов 
        /// </summary>
        private ISocrbaseRepository _socrbaseRepository;

        /// <summary>
        /// Репозитарий Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
        /// </summary>
        private IStreetRepository _streetRepository;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public KladrUnitOfWork()
        {
            _context = new KladrDbContext();
        }

        #endregion

        #region свойства репозиториев

        /// <summary>  
        ///Репозитарий Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов
        /// </summary>  
        public IAltNameRepository AltNameRepository
        {
            get
            {
                if (this._altNameRepository == null)
                {
                    this._altNameRepository = new AltNameRepository(_context);
                }
                return _altNameRepository;
            }
        }

        /// <summary>  
        /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
        /// </summary>  
        public IDomaRepository DomaRepository
        {
            get
            {
                if (this._domaRepository == null)
                {
                    this._domaRepository = new DomaRepository(_context);
                }
                return _domaRepository;
            }
        }

        /// <summary>  
        /// Репозитарий  Репозитарий Записи с объектами седьмого уровня классификации (номера квартир домов);
        /// </summary>  
        public IFlatRepository FlatRepository
        {
            get
            {
                if (this._flatRepository == null)
                {
                    this._flatRepository = new FlatRepository(_context);
                }
                return _flatRepository;
            }
        }

        /// <summary>  
        /// Репозитарий Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
        /// </summary>  
        public IKladrRepository KladrRepository
        {
            get
            {
                if (this._kladrRepository == null)
                {
                    this._kladrRepository = new KladrRepository(_context);
                }
                return _kladrRepository;
            }
        }

        /// <summary>  
        /// Репозитарий Записи с краткими наименованиями типов адресных объектов 
        /// </summary>  
        public ISocrbaseRepository SocrbaseRepository
        {
            get
            {
                if (this._socrbaseRepository == null)
                {
                    this._socrbaseRepository = new SocrbaseRepository(_context);
                }
                return _socrbaseRepository;
            }
        }

        /// <summary>  
        /// Репозитарий Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов)  
        /// </summary>  
        public IStreetRepository StreetRepository
        {
            get
            {
                if (this._streetRepository == null)
                {
                    this._streetRepository = new StreetRepository(_context);
                }
                return _streetRepository;
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
