namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public interface IDeliveryZoneModel : IBaseNotEditableDictionaryModel
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
