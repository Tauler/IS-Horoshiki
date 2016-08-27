namespace IsHoroshiki.BusinessEntities
{
    /// <summary>
    /// Базовая сущность для всех сущностей в сервисе
    /// </summary>
    public interface IBaseBusninessModel
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        int Id
        {
            get;
            set;
        }
    }
}
