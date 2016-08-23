using Microsoft.AspNet.Identity;
using IsHoroshiki.DAO.Identities;

namespace IsHoroshiki.DAO.DaoEntities.Accounts
{
    /// <summary>
    /// Конфигурация хранилища пользователя
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="store"></param>
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }
    }
}
