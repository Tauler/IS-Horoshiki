using System.Net;
using System.Runtime.Serialization;

namespace IsHoroshiki.WebApi.Controllers
{
    [DataContract]
    public class ApiResponse
    {
        /// <summary>
        /// Версия
        /// </summary>
        [DataMember]
        public string Version => "1.0.0";

        /// <summary>
        /// 1 - если успешно выполнен запрос
        /// </summary>
        [DataMember]
        public int Success
        {
            get;
            set;
        }

        /// <summary>
        /// Сообщение об ошибке, если Success = 0
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// Данные, возвращаемые запросом
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object Data
        {
            get;
            set;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="success">1 - если успешно выполнен запрос</param>
        /// <param name="data">Сообщение об ошибке, если success = 0</param>
        /// <param name="reason">Данные, возвращаемые запросом</param>
        public ApiResponse(int success, object data = null, string reason = null)
        {
            Success = success;
            Data = data;
            Reason = reason;
        }
    }
}