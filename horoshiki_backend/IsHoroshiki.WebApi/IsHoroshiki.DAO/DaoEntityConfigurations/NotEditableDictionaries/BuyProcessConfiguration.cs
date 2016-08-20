using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Базовая конфигурация нередактируемого справочника
    /// </summary>
    public class BuyProcessConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<BuyProcess>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public BuyProcessConfiguration() 
            : base("BuyProcesses")
        {
            
        }

        #endregion
    }
}
