using System;
using IsHoroshiki.DAO.DaoEntities.Editable;

namespace IsHoroshiki.DAO.DaoEntities.Integrations
{
    /// <summary>
    /// Получение чеков (заказов) из 1С
    /// </summary>
    public class IntegrationCheck : BaseDaoEntity
    {
        /// <summary>
        /// Дата получения чека
        /// </summary>
        public DateTime DateReceive
        {
            get;
            set;
        }

        /// <summary>
        /// true - если нормально нормализован
        /// </summary>
        public bool IsSuccessConvert
        {
            get;
            set;
        }

        /// <summary>
        /// Описание ошибки при конвертировании
        /// </summary>
        public string ErrorConvert
        {
            get;
            set;
        }

        /// <summary>
        /// cmd
        /// </summary>
        public string Cmd
        {
            get;
            set;
        }

        /// <summary>
        /// id
        /// </summary>
        public string IdCheck
        {
            get;
            set;
        }

        /// <summary>
        /// дата документа
        /// </summary>
        public string DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Клиент
        /// </summary>
        public string Client
        {
            get;
            set;
        }

        /// <summary>
        /// Повар
        /// </summary>
        public string Cook
        {
            get;
            set;
        }

        /// <summary>
        /// зона
        /// </summary>
        public string Zona
        {
            get;
            set;
        }

        /// <summary>
        /// раньше
        /// </summary>
        public string Before
        {
            get;
            set;
        }

        /// <summary>
        /// видзаказа
        /// </summary>
        public string OrderView
        {
            get;
            set;
        }

        /// <summary>
        /// время нач приготовления план
        /// </summary>
        public string PlanCookingTimeStart
        {
            get;
            set;
        }

        /// <summary>
        /// время кон приготовления план
        /// </summary>
        public string PlanCookingTimeEnd
        {
            get;
            set;
        }

        /// <summary>
        /// дата нач производства
        /// </summary>
        public string PlanCookingDateStart
        {
            get;
            set;
        }
       
        /// <summary>
        /// дата кон приготовления план
        /// </summary>
        public string PlanCookingDateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// время доставки план
        /// </summary>
        public string TimeDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// дата доставки план
        /// </summary>
        public string DateDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// voditel
        /// </summary>
        public string Driver
        {
            get;
            set;
        }

        /// <summary>
        /// адрес
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// АдресКЛАДР
        /// </summary>
        public string AddressKaldr
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаШ
        /// </summary>
        public string CoordinateWidth
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаД
        /// </summary>
        public string CoordinateLongitude
        {
            get;
            set;
        }

        /// <summary>
        /// Цех суши
        /// </summary>
        public string IsSushiSubDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Цех пица
        /// </summary>
        public string IsPizzaSubDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Хол цех
        /// </summary>
        public string IsCoolSubDepartment
        {
            get;
            set;
        }
    }
}
