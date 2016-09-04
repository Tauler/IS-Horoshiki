using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Время доставки
    /// </summary>
    public class DeliveryTimeRepository : BaseNotEditableRepository<DeliveryTime>, IDeliveryTimeRepository
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
