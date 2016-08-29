using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.DaoEntities.Accounts
{
    /// <summary>
    /// Логин пользователя фейсбук и т.п.
    /// </summary>
    public class CustomUserLogin : IdentityUserLogin<int>
    {
    }
}