using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
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
