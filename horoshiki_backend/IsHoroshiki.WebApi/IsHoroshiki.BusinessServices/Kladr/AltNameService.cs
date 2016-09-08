using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов
    /// </summary>
    public class AltNameService : BaseKladrBusinessService<AltName, IAltNameRepository>, IAltNameService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public AltNameService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.AltNameRepository)
        {

        }

        #endregion
    }
}
