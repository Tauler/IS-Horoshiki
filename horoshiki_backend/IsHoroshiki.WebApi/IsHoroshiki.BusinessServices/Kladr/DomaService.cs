using IsHoroshiki.DAO.Kladr.DaoEntities;
using IsHoroshiki.DAO.Kladr.Repositories.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Kladr
{
    /// <summary>
    /// Сервис Записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);
    /// </summary>
    public class DomaService : BaseKladrBusinessService<Doma, IDomaRepository>, IDomaService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public DomaService(KladrUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DomaRepository)
        {

        }

        #endregion
    }
}
