using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Конфигурация Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов
    /// </summary>
    public class AltNameConfiguration : BaseDaoEntityConfiguration<AltName>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public AltNameConfiguration()
            : base("ALTNAMES")
        {
            this.HasKey(r => new { r.OldCode, r.NewCode });

            this.Property(p => p.OldCode)
                .HasMaxLength(19)
                .HasColumnName("OLDCODE");

            this.Property(p => p.NewCode)
               .HasMaxLength(19)
               .HasColumnName("NEWCODE");

            this.Property(p => p.Level)
              .HasMaxLength(1)
              .HasColumnName("LEVEL");
        }

        #endregion
    }
}
