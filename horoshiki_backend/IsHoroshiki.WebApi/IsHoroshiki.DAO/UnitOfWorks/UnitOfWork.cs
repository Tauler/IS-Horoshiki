using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

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
        private IBuyProcessRepository _buyProcessPepository;

        /// <summary>
        /// Репозиторий Статус площадки
        /// </summary>
        private IStatusSiteRepository _statusSiteRepository;

        /// <summary>
        /// Репозиторий Должности
        /// </summary>
        private IPositionRepository _positionRepository;

        /// <summary>
        /// Репозиторий Статус сотрудника
        /// </summary>
        private IEmployeeStatusRepository _employeeStatusRepository;

        /// <summary>
        /// Репозиторий Отделы
        /// </summary>
        private IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Репозиторий Настройки заказа
        /// </summary>
        private IOrderSettingRepository _orderSettingRepository;

        /// <summary>
        /// Репозиторий Подразделения
        /// </summary>
        private ISubdivisionRepository _subdivisionRepository;

        /// <summary>
        /// Репозиторий Типы цен
        /// </summary>
        private IPriceTypeRepository _priceTypeRepository;

        /// <summary>
        /// Репозиторий Типы зон доставки
        /// </summary>
        private IDeliveryZoneTypeRepository _deliveryZoneTypeRepository;
        
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
        public IBuyProcessRepository BuyProcessPepository
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
        public IStatusSiteRepository StatusSiteRepository
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

        /// <summary>  
        /// Репозиторий Должности  
        /// </summary>  
        public IPositionRepository PositionRepository
        {
            get
            {
                if (this._positionRepository == null)
                {
                    this._positionRepository = new PositionRepository(_context);
                }
                return _positionRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Статус сотрудника  
        /// </summary>  
        public IEmployeeStatusRepository EmployeeStatusRepository
        {
            get
            {
                if (this._employeeStatusRepository == null)
                {
                    this._employeeStatusRepository = new EmployeeStatusRepository(_context);
                }
                return _employeeStatusRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Отделы  
        /// </summary>  
        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (this._departmentRepository == null)
                {
                    this._departmentRepository = new DepartmentRepository(_context);
                }
                return _departmentRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Настройки заказа  
        /// </summary>  
        public IOrderSettingRepository OrderSettingRepository
        {
            get
            {
                if (this._orderSettingRepository == null)
                {
                    this._orderSettingRepository = new OrderSettingRepository(_context);
                }
                return _orderSettingRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Подразделения  
        /// </summary>  
        public ISubdivisionRepository SubdivisionRepository
        {
            get
            {
                if (this._subdivisionRepository == null)
                {
                    this._subdivisionRepository = new SubdivisionRepository(_context);
                }
                return _subdivisionRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Типы цен  
        /// </summary>  
        public IPriceTypeRepository PriceTypeRepository
        {
            get
            {
                if (this._priceTypeRepository == null)
                {
                    this._priceTypeRepository = new PriceTypeRepository(_context);
                }
                return _priceTypeRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Типы зон доставки  
        /// </summary>  
        public IDeliveryZoneTypeRepository DeliveryZoneTypeRepository
        {
            get
            {
                if (this._deliveryZoneTypeRepository == null)
                {
                    this._deliveryZoneTypeRepository = new DeliveryZoneTypeRepository(_context);
                }
                return _deliveryZoneTypeRepository;
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
