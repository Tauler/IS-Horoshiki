using Microsoft.AspNet.Identity.EntityFramework;
using IsHoroshiki.DAO.Identity.DaoEntities;

namespace IsHoroshiki.DAO.Identity.Stores
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CustomRoleStore(IdentityDbContext context)
            : base(context)
        {
        }
    }
}