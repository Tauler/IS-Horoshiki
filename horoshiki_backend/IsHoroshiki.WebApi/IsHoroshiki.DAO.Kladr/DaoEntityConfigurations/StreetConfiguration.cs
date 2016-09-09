using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
    /// </summary>
    public class StreetConfiguration : BaseDaoEntityConfiguration<Street>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public StreetConfiguration()
            : base("STREET")
        {
            this.HasKey(r => r.Code);

            this.Property(p => p.Name)
                .HasMaxLength(40)
                .HasColumnName("NAME");

            this.Property(p => p.Socr)
              .HasMaxLength(10)
              .HasColumnName("SOCR");

            this.Property(p => p.Code)
             .HasMaxLength(17)
             .HasColumnName("CODE");

            this.Property(p => p.Index)
             .HasMaxLength(6)
             .HasColumnName("INDEX");

            this.Property(p => p.GNINMB)
             .HasMaxLength(4)
             .HasColumnName("GNINMB");

            this.Property(p => p.UNO)
             .HasMaxLength(4)
             .HasColumnName("UNO");

            this.Property(p => p.OCATD)
             .HasMaxLength(11)
             .HasColumnName("OCATD");

            this.Property(p => p.CodeRegion)
                .HasMaxLength(2)
                .HasColumnName("CODE_REGION");

            this.Property(p => p.CodeQuick)
                .HasMaxLength(11)
                .HasColumnName("CODE_QUICK");
        }

        #endregion
    }
}
