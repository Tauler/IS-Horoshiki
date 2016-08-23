using Microsoft.AspNet.Identity.EntityFramework;
using IsHoroshiki.DAO.Identity.DaoEntities;

namespace IsHoroshiki.DAO.Identity.Stores
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CustomUserStore(IdentityDbContext context)
            : base(context)
        {
        }
    }
}