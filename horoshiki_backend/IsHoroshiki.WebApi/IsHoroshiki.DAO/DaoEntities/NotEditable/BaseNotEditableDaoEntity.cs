namespace IsHoroshiki.DAO.DaoEntities.NotEditable
{
    /// <summary>
    /// Базовый нередактируемый тип справочника
    /// </summary>
    public abstract class BaseNotEditableDaoEntity : BaseDaoEntity
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
