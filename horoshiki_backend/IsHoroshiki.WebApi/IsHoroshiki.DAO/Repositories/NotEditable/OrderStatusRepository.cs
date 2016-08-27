using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Статус заказа
    /// </summary>
    public class OrderStatusRepository : BaseNotEditableDictionaryRepository<OrderStatus>, IOrderStatusRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public OrderStatusRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
