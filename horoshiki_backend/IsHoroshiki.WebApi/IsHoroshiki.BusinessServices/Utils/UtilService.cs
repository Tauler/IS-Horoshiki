using IsHoroshiki.BusinessServices.NotEditableDictionaries.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.NotEditableDictionaries
{
    /// <summary>
    /// Cервис проверки доступности сервера и т.п.
    /// </summary>
    public class UtilService : IUtilService
    {
        #region поля и свойства

        /// <summary>
        /// UnitOfWork
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        public UtilService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IUtilService

        /// <summary>
        /// true - если сервер БД доступен
        /// </summary>
        public bool IsAvailableServer()
        {
            try
            {
                _unitOfWork.BuyProcessPepository.GetById(1);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
