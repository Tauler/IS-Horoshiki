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

        SubDivisionsController _controller;

        #endregion

        [TestInitialize]
        public void SetupContext()
        {
            UnityConfig.RegisterComponents();

            var service = DependencyResolver.Current.GetService<ISubDivisionService>();
            _controller = new SubDivisionsController(service);
        }

        #region добавление 

        /// <summary>
        /// Добавление пользователя с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_NameIsNull()
        {
            var model = GetModel();
            model.Name = string.Empty;

            var result = await _controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя c часовым поясов, выходящим за интервал
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_TimezoneRange()
        {
            var model = GetModel();
            model.Timezone = Int32.MaxValue;

            var result = await _controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя c неуказанным типом цен
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_PriceTypeModelIsNull()
        {
            var model = GetModel();
            model.PriceTypeModel = null;

            var result = await _controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));

            model.PriceTypeModel = new PriceTypeModel
            {
                Id = Int32.MaxValue
            };

            result = await _controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя c указанниме типом цен и проверка его ID после сохранения
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Add_PriceTypeModelCheckId()
        {
            var model = await AddSubDivisionModelAndGet();
           
            Assert.IsNotNull(model.PriceTypeModel);
            Assert.IsTrue(model.PriceTypeModel.Id == defaultPrimeModelId);
        }

        #endregion

        #region обновление 

        /// <summary>
        /// Обновить пользователя с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_NameIsNull()
        {
            var model = await AddSubDivisionModelAndGet();

            model.Name = string.Empty;

            var updateResult = await _controller.Update(model);

            Assert.IsInstanceOfType(updateResult, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновить пользователя c часовым поясов, выходящим за интервал
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_TimezoneRange()
        {
            var model = await AddSubDivisionModelAndGet();

            model.Timezone = Int32.MaxValue;

            var updateResult = await _controller.Update(model);

            Assert.IsInstanceOfType(updateResult, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновить пользователя c не указанным типом цен
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_PriceTypeModelIsNull()
        {
            var model = await AddSubDivisionModelAndGet();

            model.PriceTypeModel = new PriceTypeModel
            {
                Id = Int32.MaxValue
            };

            var result = await _controller.Update(model);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя c указанниме типом цен и проверка его ID после сохранения
        /// </summary>
        [TestMethod]
        public async Task SubDivisionTest_Update_PriceTypeModelCheckId()
        {
            var model = await AddSubDivisionModelAndGet();

            model.PriceTypeModel = new PriceTypeModel
            {
                Id = defaultPrimeModelId
            };

            var result = await _controller.Update(model);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        #endregion

        #region Удаление

        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_UserNotExist()
        {
            var result = await _controller.Delete(Int32.MaxValue);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete()
        {
            int id = await AddSubDivisionModel();

            var result = await _controller.Delete(id);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        #endregion

        #region private

        /// <summary>
        /// Создание пользователя
        /// </summary>
        private ISubDivisionModel GetModel()
        {
            return new SubDivisionModel()
            {
                Name = "Name" + Guid.NewGuid().ToString().Replace("-", ""),
                SiteHeader = "SiteHeader" + Guid.NewGuid().ToString().Replace("-", ""),
                Timezone = 3,
                PriceTypeModel = new PriceTypeModel
                {
                    Id = defaultPrimeModelId,
                    Value = "Value" + Guid.NewGuid().ToString().Replace("-", "")
                }
            };
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <returns></returns>
        private async Task<int> AddSubDivisionModel()
        {
            var model = GetModel();
            var result = await _controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<int>));

            return (result as OkNegotiatedContentResult<int>).Content;
        }

        /// <summary>
        /// Добавить пользователя и вернуть его из БД
        /// </summary>
        /// <returns></returns>
        private async Task<ISubDivisionModel> AddSubDivisionModelAndGet()
        {
            var id = await AddSubDivisionModel();

            var getResult = await _controller.GetById(id);

            Assert.IsInstanceOfType(getResult, typeof(OkNegotiatedContentResult<ISubDivisionModel>));

            return (getResult as OkNegotiatedContentResult<ISubDivisionModel>).Content;
        }

        #endregion
    }
}
