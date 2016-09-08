using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class FlatService : BaseKladrBusinessService<Flat, IFlatRepository>, IFlatService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public FlatService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.FlatRepository)
        {

        }

        #endregion
    }
}
