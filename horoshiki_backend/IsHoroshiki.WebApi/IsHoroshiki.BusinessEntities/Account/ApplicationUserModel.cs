using IsHoroshiki.DAO.Identities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class ApplicationUserModel : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        
    }
}
