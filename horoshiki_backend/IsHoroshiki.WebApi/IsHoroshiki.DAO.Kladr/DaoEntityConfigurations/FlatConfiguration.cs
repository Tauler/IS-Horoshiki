using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Конфигурация Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class FlatConfiguration : BaseDaoEntityConfiguration<Flat>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public FlatConfiguration()
            : base("Flat")
        {
            this.HasKey(r => r.Code);

            this.Property(p => p.Code)
                .HasMaxLength(23)
                .HasColumnName("CODE");

            this.Property(p => p.NP)
               .HasMaxLength(4)
               .HasColumnName("NP");

            this.Property(p => p.GNINMB)
                .HasMaxLength(4)
                .HasColumnName("GNINMB");

            this.Property(p => p.Name)
                .HasMaxLength(40)
                .HasColumnName("NAME");

            this.Property(p => p.Index)
             .HasMaxLength(6)
             .HasColumnName("INDEX");

            this.Property(p => p.UNO)
                .HasMaxLength(4)
                .HasColumnName("UNO");
            
        }

        #endregion
    }
}
