using IsHoroshiki.DAO.DaoEntities.NotEditable;
using IsHoroshiki.DAO.Repositories.NotEditable.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace IsHoroshiki.DAO.Repositories.NotEditable
{
    /// <summary>
    /// Репозиторий Должности
    /// </summary>
    public class PositionRepository : BaseNotEditableRepository<Position>, IPositionRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public PositionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region IPositionRepository

        /// <summary>
        /// Получить список всех должностей кроме:
        /// 1) Операционного директора;
        /// 2) Управляющего рестораном;
        /// 3) Курьера
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Position>> GetPositionsOnShiftAsync()
        {
            var list = DbSet.Where(p => p.Guid != new Guid("449f1830-172a-4aec-bc29-6bb446cf8861")
                && p.Guid != new Guid("27c9376b-47b6-4eca-8920-e8a0e63f267c")
                && p.Guid != new Guid("c1fabe74-06e0-4fc6-be79-553fc2e9232b")).ToList();
            foreach (var daoEntity in list)
            {
                LoadChildEntities(daoEntity);
            }
            return list;
        }

        #endregion
    }
}
