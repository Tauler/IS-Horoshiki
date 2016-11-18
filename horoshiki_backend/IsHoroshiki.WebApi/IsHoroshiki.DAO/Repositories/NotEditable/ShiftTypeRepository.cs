using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using System.Linq;

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

        #region IShiftTypeRepository

        /// <summary>
        /// Получить тип смены - усиление
        /// </summary>
        /// <returns></returns>
        public ShiftType GetIntensification()
        {
            return DbSet.FirstOrDefault(st => st.Guid == DatabaseConstant.ShiftTypeIntensification);
        }

        #endregion
    }
}
