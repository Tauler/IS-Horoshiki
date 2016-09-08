using IsHoroshiki.DAO.DaoEntityConfigurations;
using IsHoroshiki.DAO.Kladr.DaoEntities;
using System.Data.Entity;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class KladrDbContext : DbContext
    {
        #region поля и свойства

        /// <summary>
        /// Сведения о соответствии кодов записей со старыми и новыми наименованиями
        /// </summary>
        public DbSet<AltName> AltNames
        {
            get;
            set;
        }

        /// <summary>
        /// Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
        /// </summary>
        public DbSet<Doma> Domas
        {
            get;
            set;
        }

        /// <summary>
        /// Записи с объектами седьмого уровня классификации (номера квартир домов);
        /// </summary>
        public DbSet<Flat> Flats
        {
            get;
            set;
        }

        /// <summary>
        /// Записи с объектами первых четырех уровней классификации (регионы; районы (улусы); 
        /// города, поселки городского типа, сельсоветы; сельские населенные пункты);
        /// </summary>
        public DbSet<Kladr.DaoEntities.Kladr> Kladrs
        {
            get;
            set;
        }

        /// <summary>
        /// Записи с краткими наименованиями типов адресных объектов
        /// </summary>
        public DbSet<Socrbase> Socrbases
        {
            get;
            set;
        }

        /// <summary>
        /// Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
        /// </summary>
        public DbSet<Street> Streets
        {
            get;
            set;
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public KladrDbContext()
            : base("KladrConnection")
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

            modelBuilder.Configurations.Add(new AltNameConfiguration());
            modelBuilder.Configurations.Add(new DomaConfiguration());
            modelBuilder.Configurations.Add(new FlatConfiguration());
            modelBuilder.Configurations.Add(new KladrConfiguration());
            modelBuilder.Configurations.Add(new SocrbaseConfiguration());
            modelBuilder.Configurations.Add(new StreetConfiguration());
        }

        #endregion
    }
}