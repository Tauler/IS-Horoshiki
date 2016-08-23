using System.Data.Entity;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region поля и свойства

        /// <summary>
        /// Список сущностей БД Способы покупки
        /// </summary>
        public DbSet<BuyProcess> BuyProcesses
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Статус площадки
        /// </summary>
        public DbSet<StatusSite> StatusSites
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Должности
        /// </summary>
        public DbSet<Position> Positions
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Статус сотрудника
        /// </summary>
        public DbSet<EmployeeStatus> EmployeeStatuses
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Отделы
        /// </summary>
        public DbSet<Department> Departments
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Настройки заказа
        /// </summary>
        public DbSet<OrderSetting> OrderSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Подразделения
        /// </summary>
        public DbSet<Subdivision> Subdivisions
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Типы цен
        /// </summary>
        public DbSet<PriceType> PriceTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Список сущностей БД Типы зон доставки
        /// </summary>
        public DbSet<DeliveryZoneType> DeliveryZoneTypes
        {
            get;
            set;
        }
        
        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        #endregion

        #region методы

        /// <summary>
        /// Переопредeленный метод создания БД
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BuyProcessConfiguration());
            modelBuilder.Configurations.Add(new StatusSiteConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new EmployeeStatusConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new OrderSettingConfiguration());
            modelBuilder.Configurations.Add(new SubdivisionConfiguration());
            modelBuilder.Configurations.Add(new PriceTypeConfiguration());
            modelBuilder.Configurations.Add(new DeliveryZoneTypeConfiguration());
        }

        #endregion
    }
}