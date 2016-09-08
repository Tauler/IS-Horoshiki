using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов
    /// </summary>
    public class AltNameRepository : BaseRepository<AltName>, IAltNameRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public AltNameRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion
    }
}
