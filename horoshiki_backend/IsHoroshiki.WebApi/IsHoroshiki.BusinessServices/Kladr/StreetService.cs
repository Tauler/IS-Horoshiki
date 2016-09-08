using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами пятого уровня классификации (улицы городов и населенных пунктов)
    /// </summary>
    public class StreetService : BaseKladrBusinessService<Street, IStreetRepository>, IStreetService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public StreetService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.StreetRepository)
        {

        }

        #endregion
    }
}
