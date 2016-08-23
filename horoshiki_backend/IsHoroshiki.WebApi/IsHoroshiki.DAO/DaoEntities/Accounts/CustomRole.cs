using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.DAO.Identities
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomRole()
        {
            
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Наименование</param>
        public CustomRole(string name)
        {
            Name = name;
        }
    }
}