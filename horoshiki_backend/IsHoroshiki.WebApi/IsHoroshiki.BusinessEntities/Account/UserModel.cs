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
    }
}
