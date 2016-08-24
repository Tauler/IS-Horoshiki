using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Настройки заказа
    /// </summary>
    public class OrderSettingConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<OrderSetting>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public OrderSettingConfiguration() 
            : base("OrderSettings")
        {

        }

        #endregion
    }
}
