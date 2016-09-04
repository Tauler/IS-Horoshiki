namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Базовая сущность для всех сущностей БД
    /// </summary>
    public interface IBaseDaoEntity
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
