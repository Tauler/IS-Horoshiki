namespace IsHoroshiki.BusinessEntities.NotEditable.Interfaces
{
    /// <summary>
    /// Тип смены
    /// </summary>
    public interface IShiftTypeModel : IBaseNotEditableModel
    {
        /// <summary>
        /// Сокращенное название (условное обозначение)
        /// </summary>
        string Socr
        {
            get;
            set;
        }
    }
}
