namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public interface IBaseNotEditableModel : IBaseBusninessModel
    {
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
