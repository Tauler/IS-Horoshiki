﻿using System.Collections.Generic;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable.MappingDao;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.BusinessServices.Errors.Enums;
using IsHoroshiki.BusinessServices.Validators;
using IsHoroshiki.BusinessServices.Validators.Editable.Interfaces;
using IsHoroshiki.DAO.DaoEntities.Editable;
using IsHoroshiki.DAO.Repositories.Editable.Interfaces;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.BusinessServices.Editable
{
    /// <summary>
    /// Сервис Платформа
    /// </summary>
    public class PlatformService : BaseEditableService<IPlatformModel, IPlatformValidator, Platform, IPlatformRepository>, IPlatformService
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="validator">Валидатор</param>
        public PlatformService(UnitOfWork unitOfWork, IPlatformValidator validator)
            : base(unitOfWork, unitOfWork.PlatformRepository, validator)
        {
            
        }

        #endregion

        #region protected override

        /// <summary>
        /// Получить всех
        /// </summary>
        /// <param name="pageNo">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="sortField">Поле для сортировки</param>
        /// <param name="isAscending">true - сортировать по возрастанию</param>
        /// <returns></returns>
        public override async Task<PagedResult<IPlatformModel>> GetAllAsync(int pageNo = 1, int pageSize = 50, string sortField = "", bool isAscending = true)
        {
            if (string.Equals(sortField, "SubDivision") 
                || string.Equals(sortField, "User")
                || string.Equals(sortField, "PlatformStatus"))
            {
                sortField += "Id";
            }
            
            return await base.GetAllAsync(pageNo, pageSize, sortField, isAscending);
        }

        /// <summary>
        /// Валидация сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        protected override async Task<ValidationResult> ValidationInternal(IPlatformModel model)
        {
            var result = await IsExistDaoEntity(_unitOfWork.PlatformStatusRepository, model.PlatformStatus);
            if (!result)
            {
                return new ValidationResult(PlatformErrors.PlatformStatusNotFound, model.PlatformStatus?.Id ?? 0);
            }

            result = await IsExistDaoEntity(_unitOfWork.SubDivisionRepository, model.SubDivision);
            if (!result)
            {
                return new ValidationResult(PlatformErrors.SubDivisionNotFound, model.SubDivision?.Id ?? 0);
            }

            if (model.User != null && model.User.Id > 0)
            {
                var user = await _unitOfWork.AccountRepository.GetByIdAsync(model.User.Id);
                if (user == null)
                {
                    return new ValidationResult(PlatformErrors.UserNotFound, (int) model.User?.Id);
                }
            }

            if (model.BuyProcesses != null)
            {
                foreach (var buyProcessModel in model.BuyProcesses)
                {
                    result = await IsExistDaoEntity(_unitOfWork.BuyProcessPepository, buyProcessModel);
                    if (!result)
                    {
                        return new ValidationResult(PlatformErrors.BuyProcessNotFound, buyProcessModel?.Id ?? 0);
                    }
                }
            }

            return new ValidationResult();
        }

        /// <summary>
        /// Валидация сущности при удалении
        /// </summary>
        /// <param name="daoModel">Сущность</param>
        /// <returns></returns>
        protected override ValidationResult CanDeleteInternal(Platform daoModel)
        {
            bool result = _unitOfWork.AccountRepository.IsExistForPlatform(daoModel.Id);
            if (result)
            {
                return new ValidationResult(PlatformErrors.CanNotDeleteExistUser);
            }

            return new ValidationResult();
        }

        /// <summary>
        /// Метод конвертации Dao объектa в бизнес-модель 
        /// </summary>
        /// <param name="daoEntity"></param>
        /// <returns></returns>
        protected override IPlatformModel ConvertTo(Platform daoEntity)
        {
            return daoEntity.ToModelEntity();
        }

        /// <summary>
        /// Метод конвертации коллекции Dao объектов в коллекцию бизнес-модели 
        /// </summary>
        /// <param name="collection">коллекции Dao объектов</param>
        /// <returns></returns>
        protected override IEnumerable<IPlatformModel> ConvertTo(IEnumerable<Platform> collection)
        {
            return collection.ToModelEntityList();
        }

        /// <summary>
        /// Создание DAO сущности
        /// </summary>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override Platform CreateInternal(IPlatformModel model)
        {
            var result = model.ToDaoEntity();

            UpdateDaoInternal(result, model);

            return result;
        }

        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="daoEntity">dao Сущность</param>
        /// <param name="model">Сущность</param>
        /// <returns></returns>
        public override Platform UpdateDaoInternal(Platform daoEntity, IPlatformModel model)
        {
            var result = daoEntity.Update(model);

            if (result.UserId > 0)
            {
                result.User = _unitOfWork.AccountRepository.GetByIdAsync(result.UserId.Value).Result;
            }

            result.PlatformStatus = _unitOfWork.PlatformStatusRepository.GetByIdAsync(result.PlatformStatusId).Result;
            result.SubDivision = _unitOfWork.SubDivisionRepository.GetByIdAsync(result.SubDivisionId).Result;

            result.BuyProcesses.Clear();

            if (model.BuyProcesses != null)
            {
                foreach (var bp in model.BuyProcesses)
                {
                    var daoBp = _unitOfWork.BuyProcessPepository.GetByIdAsync(bp.Id).Result;
                    if (daoBp != null)
                    {
                        result.BuyProcesses.Add(daoBp);
                    }
                }
            }
            
            return result;
        }

        #endregion
    }
}
