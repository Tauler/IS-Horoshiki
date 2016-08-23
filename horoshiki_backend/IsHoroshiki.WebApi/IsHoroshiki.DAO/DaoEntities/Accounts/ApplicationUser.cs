using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.Identities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        
    }
}