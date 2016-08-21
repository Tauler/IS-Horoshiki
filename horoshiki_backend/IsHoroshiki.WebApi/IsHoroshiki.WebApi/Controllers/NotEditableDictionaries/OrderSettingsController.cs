using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using IsHoroshiki.BusinessEntities.NotEditableDictionaries;
using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;

namespace IsHoroshiki.WebApi.Controllers.NotEditableDictionaries
{
    /// <summary>
    /// Контроллер Настройки заказа
    /// </summary>
    [Authorize]
    public class OrderSettingsController : ApiController
    {
        #region поля и свойства

        /// <summary>
        /// Cервис Статус площадки
        /// </summary>
        private readonly IOrderSettingService _service;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="service">Cервис Статус площадки</param>
        public OrderSettingsController(IOrderSettingService service)
        {
            _service = service;
        }

        #endregion

        #region методы контроллера

        /// <summary>
        /// Получить все Настройки заказа 
        /// </summary>
        /// <returns></returns>
        // GET api/BuyProcesses
        [ResponseType(typeof(IEnumerable<OrderSettingModel>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        #endregion
    }
}
