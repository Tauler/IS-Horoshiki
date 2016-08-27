namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public interface IDeliveryZoneModel : IBaseNotEditableModel
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        int Time
        {
            get;
            set;
        }
    }
}
