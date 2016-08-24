using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
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
