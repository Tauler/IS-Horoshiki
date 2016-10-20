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

        /// <summary>
        /// Подотдел - холодный цех
        /// </summary>
        public static Guid SubDepartmentCool
        {
            get
            {
                return Guid.Parse("F2E916DC-21BB-47FB-8863-7ACF15DAAB02");
            }
        }

        /// <summary>
        /// Подотдел - пицца
        /// </summary>
        public static Guid SubDepartmentPizza
        {
            get
            {
                return Guid.Parse("4A1872B9-D334-4878-A895-0E4D2E7CDA70");
            }
        }

        /// <summary>
        /// Подотдел - Цех суши
        /// </summary>
        public static Guid SubDepartmentSushi
        {
            get
            {
                return Guid.Parse("FCD7586F-EDDB-4531-BE83-E006BEB766D3");
            }
        }
    }
}
