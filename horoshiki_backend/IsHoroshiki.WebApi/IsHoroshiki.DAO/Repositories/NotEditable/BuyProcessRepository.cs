using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using System;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Способы покупки
    /// </summary>
    public class BuyProcessRepository : BaseNotEditableRepository<BuyProcess>, IBuyProcessRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public BuyProcessRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region IBuyProcessRepository

        /// <summary>
        /// Поиск по Guid
        /// </summary>
        /// <param name="guid">Guid</param>
        /// <returns></returns>
        public BuyProcess GetByGuid(Guid guid)
        {
            return DbSet.FirstOrDefault(bp => bp.Guid == guid);
        }

        #endregion
    }
}
