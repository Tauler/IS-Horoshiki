using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace IsHoroshiki.DAO.DaoEntityConfigurations
{
    /// <summary>
    /// Конфигурация Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class KladrConfiguration : BaseDaoEntityConfiguration<Kladr.DaoEntities.Kladr>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public KladrConfiguration()
            : base("KLADR")
        {
            this.HasKey(r => r.Code);


           this.Property(p => p.Name)
                .HasMaxLength(40)
                .HasColumnName("NAME")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("KLADR_NAME_CODE_ClusteredIndex", 2))); 

            this.Property(p => p.Socr)
              .HasMaxLength(10)
              .HasColumnName("SOCR");

            this.Property(p => p.Code)
             .HasMaxLength(13)
             .HasColumnName("CODE")
             .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
            {
                new IndexAttribute("KLADR_NAME_CODE_ClusteredIndex", 1),
                new IndexAttribute("KLADR_CODE_NonClusteredIndex")
            }));

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

            this.Property(p => p.Status)
                .HasMaxLength(1)
                .HasColumnName("STATUS");

            this.Property(p => p.CodeRegion)
                .HasMaxLength(2)
                .HasColumnName("CODE_REGION");

            this.Property(p => p.CodeDistrict)
                .HasMaxLength(5)
                .HasColumnName("CODE_DISTRICT");

            this.Property(p => p.CodeCity)
                .HasMaxLength(8)
                .HasColumnName("CODE_CITY");

            this.Property(p => p.CodeLocality)
                .HasMaxLength(11)
                .HasColumnName("CODE_LOCALITY");
        }

        #endregion
    }
}
