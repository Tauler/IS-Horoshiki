using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Всего кол-во сотрудников в смене на этот день (по всем сменам)
    /// </summary>
    public class ShiftCountResultColumn : IShiftCountResultColumn
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