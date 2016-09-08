using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Записи с краткими наименованиями типов адресных объектов 
    /// </summary>
    public class SocrbaseRepository : BaseRepository<Socrbase>, ISocrbaseRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SocrbaseRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion
    }
}
