using System;

namespace IsHoroshiki.DAO
{
    /// <summary>
    /// Guid записей справочников в БД
    /// </summary>
    public class DatabaseConstant
    {
        #region поля

        /// <summary>
        /// Константы отдел
        /// </summary>
        private static DatabaseConstantDepartament _departament;

        /// <summary>
        /// Константы подотдел
        /// </summary>
        private static DatabaseConstantSubDepartament _subDepartament;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        static DatabaseConstant()
        {
            _departament = new DatabaseConstantDepartament();
            _subDepartament = new DatabaseConstantSubDepartament();
        }

        #endregion

        #region свойства

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
        /// Статус работника - стажер
        /// </summary>
        public static Guid EmployeeStatusTrainee
        {
            get
            {
                return Guid.Parse("F64423DC-FB22-41F3-8FAA-DA9B38EA671D");
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
        /// Способ покупки - Доставка
        /// </summary>
        public static Guid BuyProcessDelivery
        {
            get
            {
                return Guid.Parse("FBBAE261-CD71-4FA3-AF63-E04FC1E5CB18");
            }
        }

        /// <summary>
        /// Способ покупки - Самовывоз
        /// </summary>
        public static Guid BuyProcessSelf
        {
            get
            {
                return Guid.Parse("1C47B31F-D28B-4DEF-BE40-E588CADD853B");
            }
        }

        /// <summary>
        /// Тип смены - усиление
        /// </summary>
        public static Guid ShiftTypeIntensification
        {
            get
            {
                return Guid.Parse("9849AEF4-3413-4E3E-A427-4722CFA172F6");
            }
        }

        /// <summary>
        /// Константы отдел
        /// </summary>
        public static DatabaseConstantDepartament Departament
        {
            get
            {
                return _departament;
            }
        }

        /// <summary>
        /// Константы подотдел
        /// </summary>
        public static DatabaseConstantSubDepartament SubDepartament
        {
            get
            {
                return _subDepartament;
            }
        }

        #endregion

        /// <summary>
        /// Константы отдел
        /// </summary>
        public class DatabaseConstantDepartament 
        {
            /// <summary>
            /// Колл-центр
            /// </summary>
            public Guid CallCenter
            {
                get
                {
                    return Guid.Parse("AC252958-75C9-4AFE-A685-A9E853E52994");
                }
            }

            /// <summary>
            /// Администрация
            /// </summary>
            public Guid Administration
            {
                get
                {
                    return Guid.Parse("9890056E-D74B-4057-AA54-91B403021D65");
                }
            }

            /// <summary>
            /// Производство
            /// </summary>
            public Guid Production
            {
                get
                {
                    return Guid.Parse("A011AF0E-6303-49A9-B29B-4F93E543D762");
                }
            }

            /// <summary>
            /// Отдел - доставка (курьеры)
            /// </summary>
            public Guid Courier
            {
                get
                {
                    return Guid.Parse("D8CCFE34-38A0-47FC-AD64-2C13BDA0678B");
                }
            }
        }

        /// <summary>
        /// Константы подотдел
        /// </summary>
        public class DatabaseConstantSubDepartament
        {
            /// <summary>
            /// Подотдел - холодный цех
            /// </summary>
            public Guid Cool
            {
                get
                {
                    return Guid.Parse("F2E916DC-21BB-47FB-8863-7ACF15DAAB02");
                }
            }

            /// <summary>
            /// пицца
            /// </summary>
            public Guid Pizza
            {
                get
                {
                    return Guid.Parse("4A1872B9-D334-4878-A895-0E4D2E7CDA70");
                }
            }

            /// <summary>
            /// Цех суши
            /// </summary>
            public Guid Sushi
            {
                get
                {
                    return Guid.Parse("FCD7586F-EDDB-4531-BE83-E006BEB766D3");
                }
            }

            /// <summary>
            /// Уборка
            /// </summary>
            public Guid Cleaner
            {
                get
                {
                    return Guid.Parse("441BB133-844B-452E-A720-F4E25E330528");
                }
            }
        }
    }
}
