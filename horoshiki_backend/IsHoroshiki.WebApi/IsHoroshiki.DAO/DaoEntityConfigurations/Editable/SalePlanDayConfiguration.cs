using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.Editable
{
    /// <summary>
    /// Конфигурация  День плана продаж
    /// </summary>
    public class SalePlanDayConfiguration : BaseDaoEntityConfiguration<SalePlanDay>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public SalePlanDayConfiguration() 
            : base("SalePlanDays")
        {
           
        }

        #endregion
    }
}
