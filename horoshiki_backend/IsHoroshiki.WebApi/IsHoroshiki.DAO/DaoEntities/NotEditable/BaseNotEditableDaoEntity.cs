using System;

namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableDaoEntity : BaseDaoEntity
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}
