using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация Платформа
    /// </summary>
    public class PlatformConfiguration : BaseDaoEntityConfiguration<Platform>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public PlatformConfiguration() 
            : base("Platforms")
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Address)
                .HasMaxLength(250);

            Property(p => p.YandexMap)
                .HasMaxLength(1000);

            HasMany(s => s.BuyProcesses)
                .WithRequired();

            HasMany(p => p.BuyProcesses)
                .WithMany(bp => bp.Platforms)
                .Map(mc =>
                {
                    mc.ToTable("Platform_BuyProcess_Link");
                    mc.MapLeftKey("PlatformId");
                    mc.MapRightKey("BuyProcessId");
                });

            HasRequired(s => s.PlatformStatus);

            HasOptional(s => s.User)
                .WithMany(s => s.Platforms)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.SubDivision);

            Property(i => i.MinCheck)
                .HasColumnType("Money");
        }

        #endregion
    }
}
