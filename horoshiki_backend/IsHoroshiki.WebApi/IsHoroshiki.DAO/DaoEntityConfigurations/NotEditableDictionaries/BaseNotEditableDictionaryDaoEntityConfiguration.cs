using System;
using System.Data.Entity.ModelConfiguration;
using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Helpers;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Базовая конфигурация нередактируемого справочника
    /// </summary>
    public abstract class BaseNotEditableDictionaryDaoEntityConfiguration<TDaoEntity> : EntityTypeConfiguration<TDaoEntity>
        where TDaoEntity : BaseNotEditableDictionaryDaoEntity
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="tableName">Наименование таблицы</param>  
        protected BaseNotEditableDictionaryDaoEntityConfiguration(string tableName)
        {
            tableName.ThrowIfNull();

            ToTable(tableName);
            HasKey(p => p.Id);

            Property(p => p.Id)
                .IsRequired();

            Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(100);
        }

        #endregion
    }
}
