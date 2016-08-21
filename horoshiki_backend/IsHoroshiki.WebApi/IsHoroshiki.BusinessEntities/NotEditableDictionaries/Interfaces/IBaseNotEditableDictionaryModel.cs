namespace IsHoroshiki.BusinessEntities.NotEditableDictionaries.Interfaces
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public interface IBaseNotEditableDictionaryModel : IBaseBusninessModel
    {
        /// <summary>
        /// Id в БД
        /// </summary>
        int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Значение
        /// </summary>
        string Value
        {
            get;
            set;
        }
    }
}
