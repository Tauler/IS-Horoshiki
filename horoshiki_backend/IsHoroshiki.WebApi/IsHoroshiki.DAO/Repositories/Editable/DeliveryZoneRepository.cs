using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        #region IDeliveryZoneRepository

        /// <summary>  
        /// Получить все записи для площадки
        /// </summary>  
        /// <param name="platformId">Id площадки</param>
        public IEnumerable<DeliveryZone> GetAllByPlatform(int platformId)
        {
            var result = DbSet.Where(d => d.PlatformId == platformId).ToList();

            foreach (var entity in result)
            {
                LoadChildEntities(entity);
            }

            return result;
        }

        #endregion
    }
}
