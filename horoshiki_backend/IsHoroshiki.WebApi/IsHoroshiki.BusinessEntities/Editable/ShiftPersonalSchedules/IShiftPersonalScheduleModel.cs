using IsHoroshiki.BusinessEntities.Editable.Interfaces;

namespace IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules
{
    /// <summary>
    /// Планированиe графика работы сотрудников на период
    /// </summary>
    public interface IShiftPersonalScheduleModel : IBaseBusninessModel
    {
        /// <summary>
        /// Площадка
        /// </summary>
        IPlatformModel Platform
        {
            get;
            set;
        }
    }
}