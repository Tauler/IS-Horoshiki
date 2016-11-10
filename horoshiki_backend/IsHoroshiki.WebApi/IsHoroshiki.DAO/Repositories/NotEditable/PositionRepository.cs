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

        /// <summary>
        /// Получить список должностей без Операционного дитектора, Управляющего рестораном и Курьера
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Position>> GetPositionsOnShiftAsync()
        {
            var list = DbSet.Where(p => FilterPositionsOnShift(p)).ToList();
            foreach (var daoEntity in list)
            {
                LoadChildEntities(daoEntity);
            }
            return list;
        }

        #region private

        /// <summary>
        /// Проверяет что должность не является Операционным дитектором, Управляющим рестораном и Курьером
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool FilterPositionsOnShift(Position position)
        {
            if (position.Guid == new Guid("449f1830-172a-4aec-bc29-6bb446cf8861")
                || position.Guid == new Guid("27c9376b-47b6-4eca-8920-e8a0e63f267c")
                || position.Guid == new Guid("c1fabe74-06e0-4fc6-be79-553fc2e9232b"))
                return false;
            return true;
        }

        #endregion
    }
}
