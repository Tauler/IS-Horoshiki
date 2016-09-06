using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Лайт-версия пользователя
    /// </summary>
    public class UserModel : BaseBusninessModel, IUserModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get;
            set;
        }
    }
}
