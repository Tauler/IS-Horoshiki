using System;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables
{
    /// <summary>
    /// Строка таблицы Кол-во чеков на этот день из плана продаж
    /// </summary>
    public interface ISalePlanCountColumnModel
    {
        /// <summary>
        /// Дата (день недели)
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }


        /// <summary>
        /// Кол-во чеков
        /// </summary>
        int Count
        {
            get;
            set;
        }
    }
}