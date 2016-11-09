using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Тип смены
    /// </summary>
    public class ShiftTypeRepository : BaseNotEditableRepository<ShiftType>, IShiftTypeRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public ShiftTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion
    }
}
