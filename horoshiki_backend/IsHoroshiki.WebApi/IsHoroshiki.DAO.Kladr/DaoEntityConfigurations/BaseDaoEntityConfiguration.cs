using IsHoroshiki.DAO.Kladr;
using System;
using System.Data.Entity.ModelConfiguration;

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
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException();
            }

            ToTable(tableName);
        }

        #endregion
    }
}
