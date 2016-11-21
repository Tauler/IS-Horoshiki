using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене на этот день
    /// </summary>
    public interface IShiftCountByTypeColumn
    {
        /// <summary>
        /// Дата 
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во 
        /// </summary>
        int Count
        {
            get;
            set;
        }
    }
}