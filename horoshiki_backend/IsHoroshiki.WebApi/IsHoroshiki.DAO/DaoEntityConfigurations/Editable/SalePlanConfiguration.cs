using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация План продаж
    /// </summary>
    public class SalePlanConfiguration : BaseDaoEntityConfiguration<SalePlan>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SalePlanConfiguration() 
            : base("SalePlans")
        {
            Property(i => i.AverageCheck)
               .HasColumnType("Money");
        }

        #endregion
    }
}
