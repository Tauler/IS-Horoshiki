using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Типы цен
    /// </summary>
    public class ShiftTypeConfiguration : BaseNotEditableDaoEntityConfiguration<ShiftType>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public ShiftTypeConfiguration() 
            : base("ShiftTypes")
        {
            Property(p => p.Socr)
               .IsRequired()
               .HasMaxLength(25);
        }

        #endregion
    }
}
