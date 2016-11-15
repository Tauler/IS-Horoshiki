using IsHoroshiki.DAO.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonals
{
    public class ShiftPersonalHelper : IShiftPersonalHelper
    {
        #region Поля и свойства

        /// <summary>
        /// Единица работы
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">Единица работы</param>
        public ShiftPersonalHelper(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region IShiftPersonalHelper
        #endregion
    }
}
