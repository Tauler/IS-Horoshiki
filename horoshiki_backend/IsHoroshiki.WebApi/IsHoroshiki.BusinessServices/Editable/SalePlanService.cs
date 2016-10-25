using System.Collections.Generic;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.SalePlan;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.SalePlans.Result;
using IsHoroshiki.BusinessServices.Editable.SalePlans;
using IsHoroshiki.BusinessEntities.Editable.SalePlans;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Errors.ErrorDatas;
using System;
using System.Linq;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис План продаж
    /// </summary>
    public class SalePlanService : BaseEditableService<ISalePlanModel, ISalePlanValidator, SalePlan, ISalePlanRepository>, ISalePlanService
    {
        #region Конструктор

        /// <summary>
        /// Хелпер построения плана подаж
        /// </summary>
        private readonly ISalePlanHelper _salePlanHelper;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public SalePlanService(UnitOfWork unitOfWork, ISalePlanValidator validator, ISalePlanHelper salePlanHelper)
             : base(unitOfWork, unitOfWork.SalePlanRepository, validator)
        {
            this._salePlanHelper = salePlanHelper;
        }

        #endregion

        #region ISalePlanService

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        public async Task<SalePlanTableModel> Add(ISalePlanModel model)
        {
            if (model == null)
            {
                return null;
            }

            var validateResult = await _validator.ValidateAsync(model);
            if (!validateResult.IsSucceeded)
            {
                throw new Exception(validateResult.Errors.First().Message);
            }

            return await this._salePlanHelper.Get(model);
        }

        /// <summary>
        /// Создать\Редактировать план
        /// </summary>
        public async Task<SalePlanTableModel> Update(ISalePlanModel model)
        {
            if (model == null)
            {
                return null;
            }

            var validateResult = await _validator.ValidateAsync(model);
            if (!validateResult.IsSucceeded)
            {
                throw new Exception(validateResult.Errors.First().Message);
            }

            return await this._salePlanHelper.Get(model);
        }

        /// <summary>
        /// Редактировать cредний чек плана 
        /// </summary>
        public async Task<ModelEntityModifyResult> UpdateAverageCheck(ISalePlanModel model)
        {
            if (model == null)
            {
                return new ModelEntityModifyResult(CommonErrors.EntityUpdateIsNull);
            }

            var daoEntity = await _repository.GetByIdAsync(model.Id);
            if (daoEntity == null)
            {
                var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { model.Id });
                return new ModelEntityModifyResult(errorData);
            }

            if (model.AverageCheck == 0)
            {
                return new ModelEntityModifyResult(SalePlanErrors.AverageCheckIsNull);
            }

            daoEntity.AverageCheck = model.AverageCheck;

            _repository.Update(daoEntity);
            _unitOfWork.Save();

            return new ModelEntityModifyResult();
        }

        /// <summary>
        /// Редактировать ячейку отчета
        /// </summary>
        public async Task<ModelEntityModifyResult> UpdateCell(ISalePlanDayModel model)
        {
            try
            {
                if (model == null)
                {
                    return new ModelEntityModifyResult(CommonErrors.Exception);
                }

                var daoEntity = await _unitOfWork.SalePlanDayRepository.GetByIdAsync(model.Id);
                if (daoEntity == null)
                {
                    var errorData = new ErrorData(CommonErrors.EntityUpdateNotFound, parameters: new object[] { model.Id });
                    return new ModelEntityModifyResult(errorData);
                }

                daoEntity.Delivery = model.Delivery;
                daoEntity.Self = model.Self;

                _unitOfWork.SalePlanDayRepository.Update(daoEntity);
                _unitOfWork.Save();

                return new ModelEntityModifyResult();
            }
            catch (Exception e)
            {
                var errorData = new ErrorData(CommonErrors.Exception, e.Message);
                return new ModelEntityModifyResult(errorData);
            }
        }

        #endregion
   
        #region protected override

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override ISalePlanModel ConvertTo(SalePlan daoEntity)
        {
            return new SalePlanModel();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<ISalePlanModel> ConvertTo(IEnumerable<SalePlan> collection)
        {
            return new List<ISalePlanModel>();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SalePlan CreateInternal(ISalePlanModel model)
        {
            return new SalePlan();
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override SalePlan UpdateDaoInternal(SalePlan daoEntity, ISalePlanModel model)
        {
            return daoEntity;
        }

        #endregion
    }
}
