using System.Data.Entity.ModelConfiguration;
using IsHoroshiki.DAO.Helpers;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Базовая конфигурация
    /// </summary>
    public abstract class BaseDaoEntityConfiguration<TDaoEntity> : EntityTypeConfiguration<TDaoEntity>
        where TDaoEntity : BaseDaoEntity
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="tableName">Наименование таблицы</param>  
        protected BaseDaoEntityConfiguration(string tableName)
        {
            tableName.ThrowIfNull();

            ToTable(tableName);
            HasKey(p => p.Id);

            Property(p => p.Id)
                .IsRequired();
        }

        #endregion
    }
}
