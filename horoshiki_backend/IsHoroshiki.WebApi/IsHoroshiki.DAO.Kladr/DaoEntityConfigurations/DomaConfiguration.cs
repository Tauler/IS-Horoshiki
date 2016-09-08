using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Конфигурация Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class DomaConfiguration : BaseDaoEntityConfiguration<Doma>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DomaConfiguration()
            : base("Doma")
        {
            this.HasKey(r => r.Code);

            this.Property(p => p.Name)
                .HasMaxLength(40)
                .HasColumnName("NAME");

            this.Property(p => p.Korp)
               .HasMaxLength(10)
               .HasColumnName("KORP");

            this.Property(p => p.Socr)
              .HasMaxLength(10)
              .HasColumnName("SOCR");

            this.Property(p => p.Code)
             .HasMaxLength(19)
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
        }

        #endregion
    }
}
