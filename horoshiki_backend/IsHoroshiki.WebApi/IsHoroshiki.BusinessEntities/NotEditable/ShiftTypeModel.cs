using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;

namespace IsHoroshiki.BusinessEntities.NotEditable
{
    /// <summary>
    /// Тип смены
    /// </summary>
    public class ShiftTypeModel : BaseNotEditableModel, IShiftTypeModel
    {
        /// <summary>
        /// Сокращенное название (условное обозначение)
        /// </summary>
        public string Socr
        {
            get;
            set;
        }
    }
}
