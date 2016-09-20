using System;

namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public interface IBaseNotEditableModel : IBaseBusninessModel
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Значение
        /// </summary>
        string Value
        {
            get;
            set;
        }
    }
}
