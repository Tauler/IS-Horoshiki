using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Оплата заказа
    /// </summary>
    public class OrderPayConfiguration : BaseNotEditableDaoEntityConfiguration<OrderPay>
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
