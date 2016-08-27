using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Типы цен
    /// </summary>
    public class PriceTypeConfiguration : BaseNotEditableDaoEntityConfiguration<PriceType>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public PriceTypeConfiguration() 
            : base("PriceTypes")
        {

        }

        #endregion
    }
}
