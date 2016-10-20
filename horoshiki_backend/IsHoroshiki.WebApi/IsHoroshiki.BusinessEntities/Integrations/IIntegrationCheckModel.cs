namespace IsHoroshiki.BusinessEntities.Integrations
{
    /// <summary>
    /// Получение чеков (заказов) из 1С
    /// </summary>
    public interface IIntegrationCheckModel
    {
        /// <summary>
        /// cmd
        /// </summary>
        string Cmd
        {
            get;
            set;
        }

        /// <summary>
        /// id
        /// </summary>
        string Id
        {
            get;
            set;
        }

        /// <summary>
        /// дата документа
        /// </summary>
        string DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Статус
        /// </summary>
        string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Клиент
        /// </summary>
        string Klient
        {
            get;
            set;
        }

        /// <summary>
        /// Повар
        /// </summary>
        string Cook
        {
            get;
            set;
        }

        /// <summary>
        /// зона
        /// </summary>
        string Zona
        {
            get;
            set;
        }

        /// <summary>
        /// раньше
        /// </summary>
        string Before
        {
            get;
            set;
        }

        /// <summary>
        /// видзаказа
        /// </summary>
        string OrderView
        {
            get;
            set;
        }

        /// <summary>
        /// время нач приготовления план
        /// </summary>
        string TimeStartCooking
        {
            get;
            set;
        }

        /// <summary>
        /// время кон приготовления план
        /// </summary>
        string TimeEndCooking
        {
            get;
            set;
        }

        /// <summary>
        /// дата нач производства
        /// </summary>
        string DateStartMaking
        {
            get;
            set;
        }
       
        /// <summary>
        /// дата кон приготовления план
        /// </summary>
        string DateEndMaking
        {
            get;
            set;
        }

        /// <summary>
        /// время доставки план
        /// </summary>
        string TimeDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// дата доставки план
        /// </summary>
        string DateDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// voditel
        /// </summary>
        string Driver
        {
            get;
            set;
        }

        /// <summary>
        /// адрес
        /// </summary>
        string Address
        {
            get;
            set;
        }

        /// <summary>
        /// АдресКЛАДР
        /// </summary>
        string AddressKaldr
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаШ
        /// </summary>
        string CoordinateWidth
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаД
        /// </summary>
        string CoordinateLongitude
        {
            get;
            set;
        }

        /// <summary>
        /// Цех суши
        /// </summary>
        string IsSushiDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Цех пица
        /// </summary>
        string IsPizzaDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Хол цех
        /// </summary>
        string IsCoolDepartment
        {
            get;
            set;
        }
    }
}
