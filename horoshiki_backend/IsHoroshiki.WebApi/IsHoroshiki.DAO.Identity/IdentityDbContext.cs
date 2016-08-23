using IsHoroshiki.DAO.Identity.DaoEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.Identity
{
    /// <summary>
    /// Контекст IdentityDbContext
    /// </summary>
    public class IdentityDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public IdentityDbContext()
            : base("DefaultConnection")
        {
        }
        
        /// <summary>
        /// Создать контекст
        /// </summary>
        /// <returns></returns>
        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}