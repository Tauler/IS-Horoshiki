using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Причины увольнения сотрудника
    /// </summary>
    public class SaleCheckConfiguration : BaseDaoEntityConfiguration<SaleCheck>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SaleCheckConfiguration() 
            : base("SaleChecks")
        {
            Property(p => p.IdCheck)
                .HasMaxLength(100);

            HasMany(p => p.SubDepartments)
                .WithMany(bp => bp.SaleChecks)
                .Map(mc =>
                {
                    mc.ToTable("SubDepartments_SaleChecks_Link");
                    mc.MapLeftKey("SaleCheckId");
                    mc.MapRightKey("SubDepartmentId");
                });

            Property(i => i.Sum)
                .HasColumnType("Money");
        }

        #endregion
    }
}
