using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Кол-во сотрудников в смене
    /// </summary>
    public class ShiftCountByTypeColumn : IShiftCountByTypeColumn
    {
        /// <summary>
        /// Дата 
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Кол-во 
        /// </summary>
        public int Count
        {
            get;
            set;
        }
    }
}