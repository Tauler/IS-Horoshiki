using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Способы покупки
    /// </summary>
    public class StatusSiteConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<StatusSite>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public StatusSiteConfiguration() 
            : base("StatusSites")
        {

        }

        #endregion
    }
}
