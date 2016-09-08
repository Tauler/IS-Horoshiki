using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;

namespace IsHoroshiki.DAO.Kladr.Repositories
{
    /// <summary>
    /// Репозитарий Репозитарий Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class FlatRepository : BaseRepository<Flat>, IFlatRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public FlatRepository(KladrDbContext context)
            : base(context)
        {
            this.Context = context;
        }

        #endregion
    }
}
