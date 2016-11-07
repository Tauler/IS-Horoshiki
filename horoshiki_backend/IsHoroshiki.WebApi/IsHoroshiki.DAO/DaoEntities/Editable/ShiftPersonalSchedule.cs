using IsHoroshiki.DAO.DaoEntities.Accounts;

namespace IsHoroshiki.DAO.DaoEntities.Editable
{
    /// <summary>
    /// График периода смен работника
    /// </summary>
    public class ShiftPersonalSchedule : BaseDaoEntity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public ApplicationUser User
        {
            get;
            set;
        }

        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserId
        {
            get;
            set;
        }
    }
}
