using System;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Guid записей справочников в БД
    /// </summary>
    public static class DatabaseConstant
    {
        /// <summary>
        /// Статус работника - уволен
        /// </summary>
        public static Guid EmployeeStatusDismissal
        {
            get
            {
                return Guid.Parse("104688A6-9CD2-4FB9-AB03-9DA1B5474BE0");
            }
        }

        /// <summary>
        /// Должность - Операционный директор
        /// </summary>
        public static Guid PositionOperationDirector
        {
            get
            {
                return Guid.Parse("449F1830-172A-4AEC-BC29-6BB446CF8861");
            }
        }

        /// <summary>
        /// Должность - управлющий
        /// </summary>
        public static Guid PositionManager
        {
            get
            {
                return Guid.Parse("27C9376B-47B6-4ECA-8920-E8A0E63F267C");
            }
        }
    }
}
