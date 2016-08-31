using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHoroshiki.BusinessEntities.Account;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.WebApi.Controllers.Editable;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessEntities.Account.Interfaces;

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

        #region Добавление пользователя 

        /// <summary>
        /// Добавление пользователя с пустым логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_FirstNameIsNull()
        {
            var userModel = GetApplicationUserModel();
            userModel.FirstName = string.Empty;

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с пустой фамилией
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_LastNameIsNull()
        {
            var userModel = GetApplicationUserModel();
            userModel.LastName = string.Empty;

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с пустым паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PasswordIsNull()
        {
            var userModel = GetApplicationUserModel();
            userModel.Password = string.Empty;

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с несовпадаюшим паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PasswordNotConfirm()
        {
            var userModel = GetApplicationUserModel();
            userModel.ConfirmPassword += "111";

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с не существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PositionNotExist()
        {
            var userModel = GetApplicationUserModel();
            userModel.Position = new PositionModel()
            {
                Id = Int32.MaxValue
            };
            
            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));

            userModel.Position = null;

            result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PositionExist()
        {
            var userModel = GetApplicationUserModel();
            userModel.Position = new PositionModel()
            {
                Id = 1
            };

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// Добавление пользователя с не существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_EmployeeStatusNotExist()
        {
            var userModel = GetApplicationUserModel();
            userModel.EmployeeStatus = new EmployeeStatusModel()
            {
                Id = Int32.MaxValue
            };

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));

            userModel.EmployeeStatus = null;

            result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_EmployeeStatusExist()
        {
            var userModel = GetApplicationUserModel();
            userModel.EmployeeStatus = new EmployeeStatusModel()
            {
                Id = 1
            };

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// Добавление пользователя с пустой датой окончания медкнижки, если выставлен флаг что она есть
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_MedicalBookEndNotNullIfIsHaveMedicalBook()
        {
            var userModel = GetApplicationUserModel();
            userModel.IsHaveMedicalBook = true;
            userModel.MedicalBookEnd = null;

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Добавление пользователя с проверкой что добавился
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_User()
        {
            var userModel = GetApplicationUserModel();

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(OkResult));

            var isExistResult = await _controller.IsExistUserName(userModel.UserName);

            var res = isExistResult as OkNegotiatedContentResult<bool>;

            Assert.IsTrue(res.Content);
        }

        /// <summary>
        /// Повторное добавление пользователя с одинаковыми логинами
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_UserWithDuplicateUserName()
        {
            var userModel = GetApplicationUserModel();

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(OkResult));

            var result2 = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result2, typeof(BadRequestErrorMessageResult));
        }

        #endregion

        #region Обновление пользователя 

        /// <summary>
        /// Обновление пользователя с пустым логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_FirstNameIsNull()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.FirstName = string.Empty;

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с пустой фамилией
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_LastNameIsNull()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.LastName = string.Empty;

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с пустым паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PasswordIsNull()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.Password = string.Empty;

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с несовпадаюшим паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PasswordNotConfirm()
        {
            var userModel = GetApplicationUserModel();
            userModel.ConfirmPassword += "111";

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с не существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PositionNotExist()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.Position = new PositionModel()
            {
                Id = Int32.MaxValue
            };

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с не существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_EmployeeStatusNotExist()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.EmployeeStatus = new EmployeeStatusModel()
            {
                Id = Int32.MaxValue
            };

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя с пустой датой окончания медкнижки, если выставлен флаг что она есть
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_MedicalBookEndNotNullIfIsHaveMedicalBook()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel.IsHaveMedicalBook = true;
            userModel.MedicalBookEnd = null;

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_User()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            userModel = await GetApplicationUser(userModel.UserName);

            Assert.IsNotNull(userModel);

            userModel.LastName = Guid.NewGuid().ToString().Replace("-", "");

            var result = await _controller.Update(userModel);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// Обновление пользователя с существующим логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_UserWithDuplicateUserName()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);
           
            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            var allResult = await _controller.Get(1, 10);
            var allUsers = allResult as OkNegotiatedContentResult<PagedResult<IApplicationUserModel>>;
            var userModel2 = allUsers.Content.Data.Find(u => u.UserName != userModel.UserName) as ApplicationUserModel;

            userModel2.UserName = userModel.UserName;

            var result = await _controller.Add(userModel);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        #endregion

        #region Удаление пользователя

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_UserNotExist()
        {
            var result = await _controller.Delete(Int32.MaxValue);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete()
        {
            var userModel = GetApplicationUserModel();

            var addResult = await _controller.Add(userModel);

            Assert.IsInstanceOfType(addResult, typeof(OkResult));

            userModel = await GetApplicationUser(userModel.UserName);

            var result = await _controller.Delete(userModel.Id);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        #endregion

        #region private

        /// <summary>
        /// Создание пользователя
        /// </summary>
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
                UserName = "login" + Guid.NewGuid().ToString().Replace("-", ""),
                Password = "_Aa123456",
                ConfirmPassword = "_Aa123456",
            };
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        private async Task<ApplicationUserModel> GetApplicationUser(string userName)
        {
            var allResult = await _controller.Get(1, Int32.MaxValue);

            var allUsers = allResult as OkNegotiatedContentResult<PagedResult<IApplicationUserModel>>;

            return  allUsers.Content.Data.Find(u => u.UserName == userName) as ApplicationUserModel;
        }

        #endregion
    }
}
