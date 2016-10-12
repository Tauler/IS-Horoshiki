namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для зон доставки
    /// </summary>
    public enum DeliveryZoneErrors
    {
        /// <summary>
        /// Наименование не должно быть пустым
        /// </summary>
        NameIsNull,

        /// <summary>
        /// Тип зоны доставки не должно быть пустым
        /// </summary>
        DeliveryZoneTypeIsNull,

        /// <summary>
        /// Координаты зон не должны быть пустым
        /// </summary>
        СoordinatesIsNull,
    }
}
