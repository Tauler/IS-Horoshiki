namespace IsHoroshiki.BusinessEntities.Account.Interfaces
{
    /// <summary>
    /// Лайт-версия пользователя
    /// </summary>
    public interface IUserModel : IBaseBusninessModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        string UserName
        {
            get;
            set;
        }
    }
}
