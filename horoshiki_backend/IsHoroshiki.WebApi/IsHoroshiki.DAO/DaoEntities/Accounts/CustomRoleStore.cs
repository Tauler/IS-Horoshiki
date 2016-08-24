using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.Identities
{
    /// <summary>
    /// Хранилище ролей
    /// </summary>
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст Idenity</param>
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}