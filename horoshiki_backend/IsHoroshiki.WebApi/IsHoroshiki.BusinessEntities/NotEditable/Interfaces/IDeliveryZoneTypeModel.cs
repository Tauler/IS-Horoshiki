namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// Типы зон доставки
    /// </summary>
    public interface IDeliveryZoneTypeModel : IBaseNotEditableModel
    {
        /// <summary>
        /// Время доставки в указанную зону в минутах
        /// </summary>
        int Time
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет заливки 
        /// </summary>
        string Background
        {
            get;
            set;
        }

        /// <summary>
        /// Прозрачность заливки 
        /// </summary>
        float Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Цвет контура 
        /// </summary>
        string BorderColor
        {
            get;
            set;
        }

        /// <summary>
        /// ZIndex
        /// </summary>
        int ZIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Приоритет
        /// </summary>
        int Priority
        {
            get;
            set;
        }
    }
}
