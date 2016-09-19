using System;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Базовая сущность для всех сущностей БД
    /// </summary>
    public abstract class BaseDaoEntity : IBaseDaoEntity
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        public Guid Guid
        {
            get;
            set;
        }
    }
}
