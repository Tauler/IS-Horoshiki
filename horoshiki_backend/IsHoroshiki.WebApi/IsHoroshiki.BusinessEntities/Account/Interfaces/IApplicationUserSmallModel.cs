namespace IsHoroshiki.BusinessEntities.Account.Interfaces
{
    /// <summary>
    /// Лайт-версия пользователя
    /// </summary>
    public interface IApplicationUserSmallModel : IBaseBusninessModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Имя
        /// </summary>
        string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        string LastName
        {
            get;
            set;
        }
    }
}
