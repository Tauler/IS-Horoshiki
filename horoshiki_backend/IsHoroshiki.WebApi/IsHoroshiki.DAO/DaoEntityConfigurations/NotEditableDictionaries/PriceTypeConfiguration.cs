using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Типы цен
    /// </summary>
    public class PriceTypeConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<PriceType>
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
