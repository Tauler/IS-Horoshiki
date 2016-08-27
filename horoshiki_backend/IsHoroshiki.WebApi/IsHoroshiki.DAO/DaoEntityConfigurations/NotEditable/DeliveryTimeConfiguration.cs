using IsHoroshiki.DAO.DaoEntities.NotEditable;

namespace IsHoroshiki.DAO.DaoEntityConfigurations.NotEditable
{
    /// <summary>
    /// Конфигурация Время доставки
    /// </summary>
    public class DeliveryTimeConfiguration : BaseNotEditableDaoEntityConfiguration<DeliveryTime>
    { 
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        public DeliveryTimeConfiguration() 
            : base("DeliveryTimes")
        {

        }

        #endregion
    }
}
