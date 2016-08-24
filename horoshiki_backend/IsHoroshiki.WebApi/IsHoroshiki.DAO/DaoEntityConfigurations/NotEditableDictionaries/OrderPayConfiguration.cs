using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditableDictionaries
{
    /// <summary>
    /// Конфигурация Оплата заказа
    /// </summary>
    public class OrderPayConfiguration : BaseNotEditableDictionaryDaoEntityConfiguration<OrderPay>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public OrderPayConfiguration() 
            : base("OrderPays")
        {

        }

        #endregion
    }
}
