using IsHoroshiki.BusinessEntities.Editable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Планированиe графика работы сотрудников на период
    /// </summary>
    public class ShiftPersonalScheduleModel : BaseBusninessModel, IShiftPersonalScheduleModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        public IPlatformModel Platform
        {
            get;
            set;
        }
    }
}