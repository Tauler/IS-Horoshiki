using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Всего кол-во сотрудников в смене на этот день (по всем сменам)
    /// </summary>
    public interface IShiftCountResultColumn
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