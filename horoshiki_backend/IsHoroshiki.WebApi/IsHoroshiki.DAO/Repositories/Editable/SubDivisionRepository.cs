using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;

namespace IsHoroshiki.DAO.Repositories.Editable
{
    /// <summary>
    /// Репозиторий Подразделения
    /// </summary>
    public class SubDivisionRepository : BaseRepository<SubDivision>, ISubDivisionRepository
    {
        #region Конструктор

        /// <summary>  
        /// Конструктор  
        /// </summary>  
        /// <param name="context">Контекст выполнения БД</param>  
        public SubDivisionRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        #endregion

        #region override

        /// <summary>
        /// Действие с сущностью перед добавлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void BeforeInsert(SubDivision entity)
        {
            SetChildNull(entity);
        }

        /// <summary>
        /// Действие с сущностью перед обновлением в БД
        /// </summary>
        /// <param name="entity"></param>
        protected override void BeforeUpdate(SubDivision entity)
        {
            SetChildNull(entity);
        }

        #endregion

        #region private

        /// <summary>
        /// Действие с сущностью перед обновлением в БД
        /// </summary>
        /// <param name="entity"></param>
        private void SetChildNull(SubDivision entity)
        {
            entity.PriceType = null;
        }

        #endregion
    }
}
