using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.Repositories.Accounts;
using IsHoroshiki.DAO.Repositories.Accounts.Interfaces;

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
        /// Репозиторий Подoтделы
        /// </summary>
        private ISubDepartmentRepository _subDepartmentRepository;

        /// <summary>
        /// Репозиторий Статус заказа
        /// </summary>
        private IOrderStatusRepository _orderStatusRepository;

        /// <summary>
        /// Репозиторий Оплата заказа
        /// </summary>
        private IOrderPayRepository _orderPayRepository;

        /// <summary>
        /// Репозиторий Подразделения
        /// </summary>
        private ISubDivisionRepository _subDivisionRepository;

        /// <summary>
        /// Репозиторий Типы цен
        /// </summary>
        private IPriceTypeRepository _priceTypeRepository;

        /// <summary>
        /// Репозиторий Типы зон доставки
        /// </summary>
        private IDeliveryZoneRepository _deliveryZoneRepository;

        /// <summary>
        /// Репозиторий Время доставки
        /// </summary>
        private IDeliveryTimeRepository _deliveryTimeRepository;

        /// <summary>
        /// Репозитарий авторизации
        /// </summary>
        private IAccountRepository _accountRepository;

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
        /// Репозиторий Подoтделы  
        /// </summary>  
        public ISubDepartmentRepository SubDepartmentRepository
        {
            get
            {
                if (this._subDepartmentRepository == null)
                {
                    this._subDepartmentRepository = new SubDepartmentRepository(_context);
                }
                return _subDepartmentRepository;
            }
        }
        
        /// <summary>  
        /// Репозиторий Статус заказа  
        /// </summary>  
        public IOrderStatusRepository OrderStatusRepository
        {
            get
            {
                if (this._orderStatusRepository == null)
                {
                    this._orderStatusRepository = new OrderStatusRepository(_context);
                }
                return _orderStatusRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Оплата заказа  
        /// </summary>  
        public IOrderPayRepository OrderPayRepository
        {
            get
            {
                if (this._orderPayRepository == null)
                {
                    this._orderPayRepository = new OrderPayRepository(_context);
                }
                return _orderPayRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Подразделения  
        /// </summary>  
        public ISubDivisionRepository SubDivisionRepository
        {
            get
            {
                if (this._subDivisionRepository == null)
                {
                    this._subDivisionRepository = new SubDivisionRepository(_context);
                }
                return _subDivisionRepository;
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
        public IDeliveryZoneRepository DeliveryZoneRepository
        {
            get
            {
                if (this._deliveryZoneRepository == null)
                {
                    this._deliveryZoneRepository = new DeliveryZoneRepository(_context);
                }
                return _deliveryZoneRepository;
            }
        }

        /// <summary>  
        /// Репозиторий Время доставки  
        /// </summary>  
        public IDeliveryTimeRepository DeliveryTimeRepository
        {
            get
            {
                if (this._deliveryTimeRepository == null)
                {
                    this._deliveryTimeRepository = new DeliveryTimeRepository(_context);
                }
                return _deliveryTimeRepository;
            }
        }

        /// <summary>  
        /// Репозитарий авторизации 
        /// </summary>  
        public IAccountRepository AccountRepository
        {
            get
            {
                if (this._accountRepository == null)
                {
                    this._accountRepository = new AccountRepository(_context);
                }
                return _accountRepository;
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
