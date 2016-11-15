namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Тип смены
    /// </summary>
    public class ShiftType : BaseNotEditableDaoEntity
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
