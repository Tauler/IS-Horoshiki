using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Время доставки
    /// </summary>
    public class DeliveryTimeConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<DeliveryTime>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryTimeConfiguration() 
            : base("DeliveryTime")
        {

        }

        #endregion
    }
}
