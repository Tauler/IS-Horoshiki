using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами седьмого уровня классификации (номера квартир домов);
    /// </summary>
    public class SocrbaseService : BaseKladrBusinessService<Socrbase, ISocrbaseRepository>, ISocrbaseService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public SocrbaseService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.SocrbaseRepository)
        {

        }

        #endregion
    }
}
