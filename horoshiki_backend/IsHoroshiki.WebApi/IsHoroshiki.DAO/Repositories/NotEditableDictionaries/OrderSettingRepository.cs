using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Настройки заказа
    /// </summary>
    public class OrderSettingRepository : BaseNotEditableDictionaryRepository<OrderSetting>, IOrderSettingRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public OrderSettingRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
