using System.Threading.Tasks;
using IsHoroshiki.BusinessServices.Utils.Interfaces;
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
        public async Task<bool> IsAvailableServer()
        {
            try
            {
                var result = await _unitOfWork.BuyProcessPepository.GetByIdAsync(1);
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
