using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Статус заказа
    /// </summary>
    public class OrderStatusConfiguration : BaseNotEditableDaoEntityConfiguration<OrderStatus>
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
