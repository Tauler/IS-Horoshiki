using IsHoroshiki.BusinessEntities.Account.Interfaces;

namespace IsHoroshiki.BusinessEntities.Account
{
    /// <summary>
    /// Лайт-версия пользователя
    /// </summary>
    public class ApplicationUserSmallModel : BaseBusninessModel, IApplicationUserSmallModel
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
