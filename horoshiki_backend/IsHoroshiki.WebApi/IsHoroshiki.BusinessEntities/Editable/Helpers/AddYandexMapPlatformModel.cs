namespace IsHoroshiki.BusinessEntities.Editable
{
    /// <summary>
    /// Добавление координат в площадку
    /// </summary>
    public class AddYandexMapPlatformModel
    {
        /// <summary>
        /// Id площадки
        /// </summary>
        public int PlatformId
        {
            get;
            set;
        }

        /// <summary>
        /// Яндекс-карта координаты
        /// </summary>
        public string YandexMap
        {
            get;
            set;
        }       
    }
}
