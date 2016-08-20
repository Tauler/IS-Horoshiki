using IsHoroshiki.DAO.DaoEntities.NotEditableDictionaries;

namespace IsHoroshiki.DAO.Repositories.NotEditableDictionaries
{
    /// <summary>
    /// Репозиторий Типы зон доставки
    /// </summary>
    public class DeliveryZoneTypeRepository : BaseNotEditableDictionaryRepository<DeliveryZoneType>
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DeliveryZoneTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
