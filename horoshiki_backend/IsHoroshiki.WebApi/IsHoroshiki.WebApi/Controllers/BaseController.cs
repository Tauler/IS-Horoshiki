using System.Web.Http;
using IsHoroshiki.BusinessEntities;

namespace IsHoroshiki.WebApi.Controllers
{
    /// <summary>
    /// Абстрактный класс контроллера
    /// </summary>
    public abstract class BaseController<TModelEnty> : ApiController
        where TModelEnty : IBaseBusninessModel
    {
        

    }
}
