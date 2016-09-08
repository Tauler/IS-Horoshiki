using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);
    /// </summary>
    public class StreetRepository : BaseRepository<Street>, IStreetRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public StreetRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion
    }
}
