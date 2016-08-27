namespace IsHoroshiki.BusinessEntities.NotEditable
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableModel : BaseBusninessModel
    {
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
