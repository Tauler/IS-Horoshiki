using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;
using IsHoroshiki.DAO.Repositories.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Время доставки
    /// </summary>
    public class DeliveryTimeRepository : BaseNotEditableDictionaryRepository<DeliveryTime>, IDeliveryTimeRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DeliveryTimeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
