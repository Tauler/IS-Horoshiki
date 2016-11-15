using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий  Смена работы персонала
    /// </summary>
    public class ShiftPersonalRepository : BaseRepository<ShiftPersonal>, IShiftPersonalRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public ShiftPersonalRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
