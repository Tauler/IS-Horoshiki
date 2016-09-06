using IsHoroshiki.BusinessEntities.Editable;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using IsHoroshiki.WebApi.Controllers.Editable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Validators.Editable;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.WebApi.Handlers;

namespace IsHoroshiki.WebApi.Tests.Controllers
{
    /// <summary>
    /// Тест подразделений
    /// </summary>
    [TestClass]
    public class SubDivisionControllerTest
    {
        #region поля и свойства

        private const int defaultPrimeModelId = 1;

        /// <summary>
        /// Тип результат при удачном добавлении объекта
        /// </summary>
        private readonly Type _okAddResult = typeof(OkNegotiatedContentResult<int>);

        /// <summary>
        /// Тип результат при не удачном добавлении\обновлении\удалении объекта
        /// </summary>
        private readonly Type _errrorResult = typeof(ErrorMessageResult);

        /// <summary>
        /// Сервис площадки
        /// </summary>
        private PlatformService _platformService;

        #endregion

        [TestInitialize]
        public void SetupContext()
        {
            MessageRegister.FillMessageHolder();

            _platformService = new PlatformService(new UnitOfWork(), new PlatformValidator());
        }

        #region добавление 

        /// <summary>
        /// Добавление  с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_NameIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.Name = string.Empty;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Добавление  c часовым поясов, выходящим за интервал
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_TimezoneRange()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.Timezone = Int32.MaxValue;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Добавление  c неуказанным типом цен
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_PriceTypeModelIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.PriceTypeId = 0;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));

                model.PriceTypeId = Int32.MaxValue;

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Добавление  c указанниме типом цен и проверка его ID после сохранения
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add()
        {
            var model = await AddSubDivisionModelAndGet();
           
            Assert.IsTrue(model.PriceTypeId == defaultPrimeModelId);
        }

        #endregion

        #region обновление 

        /// <summary>
        /// Обновить  с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_NameIsNull()
        {
            using (var controller = GetController())
            {
                var model = await AddSubDivisionModelAndGet();

                model.Name = string.Empty;

                var updateResult = await controller.Update(model);

                Assert.IsInstanceOfType(updateResult, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Обновить  c часовым поясов, выходящим за интервал
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_TimezoneRange()
        {
            using (var controller = GetController())
            {
                var model = await AddSubDivisionModelAndGet();

                model.Timezone = Int32.MaxValue;

                var updateResult = await controller.Update(model);

                Assert.IsInstanceOfType(updateResult, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Обновить  c не указанным типом цен
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_PriceTypeModelIsNull()
        {
            using (var controller = GetController())
            {
                var model = await AddSubDivisionModelAndGet();

                model.PriceTypeId = Int32.MaxValue;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));
            }
        }

        /// <summary>
        /// Добавление  c указанниме типом цен и проверка его ID после сохранения
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_PriceTypeModelCheckId()
        {
            using (var controller = GetController())
            {
                var model = await AddSubDivisionModelAndGet();

                model.PriceTypeId = defaultPrimeModelId;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        #endregion

        #region Удаление

        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_UserNotExist()
        {
            using (var controller = GetController())
            {
                var result = await controller.Delete(Int32.MaxValue);

                Assert.IsInstanceOfType(result, typeof(ErrorMessageResult));
            }
        }


        /// <summary>
        /// Удаление пользователя запрещено, если есть площадка с этим пользователм
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_ForExistPlatform()
        {
            using (var controller = GetController())
            {
                var platformTest = new PlatformControllerTest();
                platformTest.SetupContext();

                var platformId = platformTest.PlatformTest_Add().Result;
                var platformModel = await _platformService.GetByIdAsync(platformId);

                var result = await controller.IsCanDelete(platformModel.AccountId);

                Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<bool>));

                var res = (result as OkNegotiatedContentResult<bool>).Content;

                Assert.IsFalse(res);
            }
        }


        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete()
        {
            using (var controller = GetController())
            {
                int id = await AddSubDivisionModel();

                var result = await controller.Delete(id);

                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        #endregion

        #region private

        /// <summary>
        /// Создание 
        /// </summary>
        private ISubDivisionModel GetModel()
        {
            return new SubDivisionModel()
            {
                Name = "Name" + Guid.NewGuid().ToString().Replace("-", ""),
                SiteHeader = "SiteHeader" + Guid.NewGuid().ToString().Replace("-", ""),
                Timezone = 3,
                PriceTypeId = defaultPrimeModelId
            };
        }

        /// <summary>
        /// Добавить 
        /// </summary>
        /// <returns></returns>
        private async Task<int> AddSubDivisionModel()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<int>));

                return (result as OkNegotiatedContentResult<int>).Content;
            }
        }

        /// <summary>
        /// Добавить и вернуть его из БД
        /// </summary>
        /// <returns></returns>
        private async Task<ISubDivisionModel> AddSubDivisionModelAndGet()
        {
            using (var controller = GetController())
            {
                var id = await AddSubDivisionModel();

                var getResult = await controller.GetById(id);

                Assert.IsInstanceOfType(getResult, typeof(OkNegotiatedContentResult<ISubDivisionModel>));

                return (getResult as OkNegotiatedContentResult<ISubDivisionModel>).Content;
            }
        }

        /// <summary>
        /// Создание контроллера
        /// </summary>
        /// <returns></returns>
        private SubDivisionsController GetController()
        {
            lock (_okAddResult)
            {
                var service = new SubDivisionService(new UnitOfWork(), new SubDivisionValidator());
                return new SubDivisionsController(service);
            }
        }

        #endregion
    }
}
