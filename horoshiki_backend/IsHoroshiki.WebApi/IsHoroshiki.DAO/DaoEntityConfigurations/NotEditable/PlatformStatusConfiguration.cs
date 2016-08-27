using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Статус площадки
    /// </summary>
    public class PlatformStatusConfiguration : BaseNotEditableDaoEntityConfiguration<PlatformStatus>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public PlatformStatusConfiguration() 
            : base("PlatformStatuses")
        {
            
        }

        #endregion
    }
}
