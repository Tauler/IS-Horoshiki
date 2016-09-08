using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class DomaRepository : BaseRepository<Doma>, IDomaRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public DomaRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion
    }
}
