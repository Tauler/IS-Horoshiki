using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Способы покупки
    /// </summary>
    public class StatusSiteConfiguration : BaseNotEditableDaoEntityConfiguration<StatusSite>
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
