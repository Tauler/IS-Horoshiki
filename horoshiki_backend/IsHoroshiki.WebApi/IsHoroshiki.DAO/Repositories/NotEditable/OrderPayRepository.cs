using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Оплата заказа
    /// </summary>
    public class OrderPayRepository : BaseNotEditableDictionaryRepository<OrderPay>, IOrderPayRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public OrderPayRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
