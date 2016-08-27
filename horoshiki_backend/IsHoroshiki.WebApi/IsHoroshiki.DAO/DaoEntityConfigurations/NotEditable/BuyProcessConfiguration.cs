using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Способы покупки
    /// </summary>
    public class BuyProcessConfiguration : BaseNotEditableDaoEntityConfiguration<BuyProcess>
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
