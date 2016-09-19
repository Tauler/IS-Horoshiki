using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Базовая конфигурация нередактируемого справочника
    /// </summary>
    public abstract class BaseNotEditableDaoEntityConfiguration<TDaoEntity> : BaseDaoEntityConfiguration<TDaoEntity>
        where TDaoEntity : BaseNotEditableDaoEntity
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="tableName">Наименование таблицы</param>  
        protected BaseNotEditableDaoEntityConfiguration(string tableName)
            : base(tableName)
        {
            Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(255);


            Property(p => p.Guid)
                .IsRequired()
                .HasColumnOrder(1);
        }

        #endregion
    }
}
