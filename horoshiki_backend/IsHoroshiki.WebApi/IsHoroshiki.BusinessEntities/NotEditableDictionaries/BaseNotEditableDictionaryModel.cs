namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableDictionaryModel : BaseBusninessModel
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}
