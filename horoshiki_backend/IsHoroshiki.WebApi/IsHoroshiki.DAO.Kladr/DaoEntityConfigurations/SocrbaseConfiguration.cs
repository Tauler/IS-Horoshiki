using IsHoroshiki.DAO.Kladr.DaoEntities;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Конфигурация Записи с краткими наименованиями типов адресных объектов
    /// </summary>
    public class SocrbaseConfiguration : BaseDaoEntityConfiguration<Socrbase>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SocrbaseConfiguration()
            : base("SOCRBASE")
        {
            this.HasKey(r => r.ScName);

            this.Property(p => p.Level)
                .HasMaxLength(5)
                .HasColumnName("LEVEL");

            this.Property(p => p.ScName)
               .HasMaxLength(10)
               .HasColumnName("SCNAME");

            this.Property(p => p.SocrName)
              .HasMaxLength(29)
              .HasColumnName("SOCRNAME");

            this.Property(p => p.Kod_T_ST)
             .HasMaxLength(3)
             .HasColumnName("KOD_T_ST");            
        }

        #endregion
    }
}
