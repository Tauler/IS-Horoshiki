using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Статус заказа
    /// </summary>
    public class OrderStatusConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<OrderStatus>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public OrderStatusConfiguration() 
            : base("OrderStatuses")
        {

        }

        #endregion
    }
}
