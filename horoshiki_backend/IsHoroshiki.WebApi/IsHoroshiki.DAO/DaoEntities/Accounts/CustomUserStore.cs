using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.DaoEntities.Accounts
{
    /// <summary>
    /// Хранилище пользователй
    /// </summary>
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст Idenity</param>
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}