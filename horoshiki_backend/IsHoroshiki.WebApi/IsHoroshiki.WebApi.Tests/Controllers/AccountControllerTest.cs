using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHoroshiki.BusinessEntities.Account;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.WebApi.Controllers.Editable;

namespace IsHoroshiki.WebApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        AccountsController _controller;

        [TestInitialize]
        public void SetupContext()
        {
            _controller = new AccountsController(new AccountService());
        }

        /// <summary>
        /// Добавление пользователя с пустым логином
        /// </summary>
        [TestMethod]
        public async Task Test_Add_FirstNameNotNull()
        {
            var userModel = GetApplicationUserModel();
            userModel.FirstName = string.Empty;


            var task = await _controller.Add(userModel);
            Assert.IsTrue(task is BadRequestErrorMessageResult);
        }

        private ApplicationUserModel GetApplicationUserModel()
        {
            return new ApplicationUserModel()
            {
                FirstName = "FirstName" + Guid.NewGuid(),
                LastName = "LastName" + Guid.NewGuid(),
                EmployeeStatus = new EmployeeStatusModel()
                {
                    Id= 1,
                    Value = "Новый статус"
                },
                Position = new PositionModel
                {
                    Id = 1,
                    Value = "PositionModel"
                },
                DateStart = DateTime.Now,
                UserName = "login_" + Guid.NewGuid(),
                Password = "_Aa123456",
                ConfirmPassword = "_Aa123456",
            };
        }
    }
}
