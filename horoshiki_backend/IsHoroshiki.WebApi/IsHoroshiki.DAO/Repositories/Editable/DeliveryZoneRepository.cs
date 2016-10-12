using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Зон доставки
    /// </summary>
    public class DeliveryZoneRepository : BaseRepository<DeliveryZone>, IDeliveryZoneRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DeliveryZoneRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void LoadChildEntities(DeliveryZone entity)
        {
            if (entity == null)
            {
                return;
            }

            Context.Entry(entity).Reference(p => p.DeliveryZoneType).Load();
        }

        #endregion
    }
}
