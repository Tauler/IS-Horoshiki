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

        /// <summary>
        /// Константы должности
        /// </summary>
        private static DatabaseConstantPosition _position;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        static DatabaseConstant()
        {
            _departament = new DatabaseConstantDepartament();
            _subDepartament = new DatabaseConstantSubDepartament();
            _position = new DatabaseConstantPosition();
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

        /// <summary>
        /// Константы должности
        /// </summary>
        public static DatabaseConstantPosition Position
        {
            get
            {
                return _position;
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

        /// <summary>
        /// Константы должности
        /// </summary>
        public class DatabaseConstantPosition
        {
            /// <summary>
            /// Операционный директор
            /// </summary>
            public Guid OperationDirector
            {
                get
                {
                    return Guid.Parse("449F1830-172A-4AEC-BC29-6BB446CF8861");
                }
            }

            /// <summary>
            /// Управляющий рестораном
            /// </summary>
            public Guid Manager
            {
                get
                {
                    return Guid.Parse("27C9376B-47B6-4ECA-8920-E8A0E63F267C");
                }
            }

            /// <summary>
            /// Менеджер смены
            /// </summary>
            public Guid ManagerShift
            {
                get
                {
                    return Guid.Parse("8AB6DB9C-36AC-4760-B2E2-43445EE11520");
                }
            }

            /// <summary>
            /// Администратор
            /// </summary>
            public Guid Administrator
            {
                get
                {
                    return Guid.Parse("4551B436-BB84-4A80-906D-F5AD5DC37D76");
                }
            }

            /// <summary>
            /// Повар сушист
            /// </summary>
            public Guid CookSichi
            {
                get
                {
                    return Guid.Parse("29F56215-45C8-484B-839C-3F2E22D5F0B7");
                }
            }

            /// <summary>
            /// Повар - универсал
            /// </summary>
            public Guid CookUniversal
            {
                get
                {
                    return Guid.Parse("EB4C9D17-B79D-46E4-BEBB-C2218AFB50CE");
                }
            }

            /// <summary>
            /// Пиццер
            /// </summary>
            public Guid Pizzer
            {
                get
                {
                    return Guid.Parse("418B8D56-EDC9-4E16-B6F8-CE68C52BDB79");
                }
            }

            /// <summary>
            /// Повар холодного цеха
            /// </summary>
            public Guid CookCold
            {
                get
                {
                    return Guid.Parse("F3031481-E4F1-4CA0-939A-78BE83C0951D");
                }
            }

            /// <summary>
            /// Упаковщик
            /// </summary>
            public Guid Packer
            {
                get
                {
                    return Guid.Parse("C6EAD0FF-B75A-4333-977C-AC24647734F7");
                }
            }

            /// <summary>
            /// Курьер
            /// </summary>
            public Guid Courier
            {
                get
                {
                    return Guid.Parse("C1FABE74-06E0-4FC6-BE79-553FC2E9232B");
                }
            }

            /// <summary>
            /// Уборщик
            /// </summary>
            public Guid Cleaner
            {
                get
                {
                    return Guid.Parse("F023CCAF-A518-4857-B352-528250B9DD23");
                }
            }            
        }
    }
}
