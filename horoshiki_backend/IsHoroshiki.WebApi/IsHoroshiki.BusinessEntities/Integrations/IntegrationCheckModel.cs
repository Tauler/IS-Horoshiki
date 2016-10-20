using Newtonsoft.Json;

namespace IsHoroshiki.BusinessEntities.Integrations
{
    //    POST={'cmd': 'order', 'id': 'ПР281100', 'дата документа': '18.10.16', 'status': 'готов', 'klient': '570989', 'повар': '0170', 
    //    'зона': '2', 'раньше': '0', 
    //    'видзаказа': 'предварительный',
    //'время нач приготовления план': '14.35', 
    //    'дата нач производства': '18.10.16', 
    //    'время кон приготовления план': '14.50', 'дата кон приготовления план': '18.10.16', 
    //    'время доставки план': '15.30', 'дата доставки план': '18.10.16', 'voditel'
    //: '', 'адрес': ',644022,Омская обл,,Омск г,,Ватутина ул,9,,138,',
    //    'АдресКЛАДР': ',644022,Омская обл,,Омск г,,Ватутина ул,9,,138,',
    //    'КоординатаШ': '0', 'КоординатаД': '0', 'Цех суши': '1', 'Цех пица': '0', 'Хол цех': '0'}

    /// <summary>
    /// Получение чеков (заказов) из 1С
    /// </summary>
    public class IntegrationCheckModel : IIntegrationCheckModel
    {
        /// <summary>
        /// cmd
        /// </summary>
        [JsonProperty(PropertyName = "cmd")]
        public string Cmd
        {
            get;
            set;
        }

        /// <summary>
        /// id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// дата документа
        /// </summary>
        [JsonProperty(PropertyName = "дата документа")]
        public string DateDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Клиент
        /// </summary>
        [JsonProperty(PropertyName = "klient")]
        public string Klient
        {
            get;
            set;
        }

        /// <summary>
        /// Повар
        /// </summary>
        [JsonProperty(PropertyName = "повар")]
        public string Cook
        {
            get;
            set;
        }

        /// <summary>
        /// зона
        /// </summary>
        [JsonProperty(PropertyName = "зона")]
        public string Zona
        {
            get;
            set;
        }

        /// <summary>
        /// раньше
        /// </summary>
        [JsonProperty(PropertyName = "раньше")]
        public string Before
        {
            get;
            set;
        }

        /// <summary>
        /// видзаказа
        /// </summary>
        [JsonProperty(PropertyName = "видзаказа")]
        public string OrderView
        {
            get;
            set;
        }

        /// <summary>
        /// время нач приготовления план
        /// </summary>
        [JsonProperty(PropertyName = "время нач приготовления план")]
        public string TimeStartCooking
        {
            get;
            set;
        }

        /// <summary>
        /// время кон приготовления план
        /// </summary>
        [JsonProperty(PropertyName = "время кон приготовления план")]
        public string TimeEndCooking
        {
            get;
            set;
        }

        /// <summary>
        /// дата нач производства
        /// </summary>
        [JsonProperty(PropertyName = "дата нач производства")]
        public string DateStartMaking
        {
            get;
            set;
        }
       
        /// <summary>
        /// дата кон приготовления план
        /// </summary>
        [JsonProperty(PropertyName = "дата кон приготовления план")]
        public string DateEndMaking
        {
            get;
            set;
        }

        /// <summary>
        /// время доставки план
        /// </summary>
        [JsonProperty(PropertyName = "время доставки план")]
        public string TimeDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// дата доставки план
        /// </summary>
        [JsonProperty(PropertyName = "дата доставки план")]
        public string DateDelivery
        {
            get;
            set;
        }

        /// <summary>
        /// voditel
        /// </summary>
        [JsonProperty(PropertyName = "voditel")]
        public string Driver
        {
            get;
            set;
        }

        /// <summary>
        /// адрес
        /// </summary>
        [JsonProperty(PropertyName = "адрес")]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// АдресКЛАДР
        /// </summary>
        [JsonProperty(PropertyName = "АдресКЛАДР")]
        public string AddressKaldr
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаШ
        /// </summary>
        [JsonProperty(PropertyName = "КоординатаШ")]
        public string CoordinateWidth
        {
            get;
            set;
        }

        /// <summary>
        /// КоординатаД
        /// </summary>
        [JsonProperty(PropertyName = "КоординатаД")]
        public string CoordinateLongitude
        {
            get;
            set;
        }

        /// <summary>
        /// Цех суши
        /// </summary>
        [JsonProperty(PropertyName = "Цех суши")]
        public string IsSushiDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Цех пица
        /// </summary>
        [JsonProperty(PropertyName = "Цех пица")]
        public string IsPizzaDepartment
        {
            get;
            set;
        }

        /// <summary>
        /// Хол цех
        /// </summary>
        [JsonProperty(PropertyName = "Хол цех")]
        public string IsCoolDepartment
        {
            get;
            set;
        }
    }
}
