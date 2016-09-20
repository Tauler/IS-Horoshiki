using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHoroshiki.BusinessEntities.Account;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.WebApi.Controllers.Editable;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessEntities.Account.Interfaces;
using IsHoroshiki.BusinessServices;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Validators.Editable;
using IsHoroshiki.WebApi.Handlers;
using IsHoroshiki.DAO.UnitOfWorks;

namespace IsHoroshiki.WebApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        #region поля и свойства

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

        #region Добавление пользователя 

        /// <summary>
        /// Добавление пользователя с пустым логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_FirstNameIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.FirstName = string.Empty;

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с пустой фамилией
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_LastNameIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.LastName = string.Empty;

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с пустым паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PasswordIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.Password = string.Empty;

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с несовпадаюшим паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PasswordNotConfirm()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.ConfirmPassword += "111";

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с не существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PositionNotExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.Position = new PositionModel()
                {
                    Id = Int32.MaxValue
                };

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);

                userModel.Position = null;

                result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_PositionExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.Position = new PositionModel()
                {
                    Id = 1
                };

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _okAddResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с не существующим Id отдела
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_DepartmentNotExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.Department = new DepartmentModel()
                {
                    Id = Int32.MaxValue
                };

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с не существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_EmployeeStatusNotExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.EmployeeStatus = new EmployeeStatusModel()
                {
                    Id = Int32.MaxValue
                };

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);

                userModel.EmployeeStatus = null;

                result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_EmployeeStatusExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.EmployeeStatus = new EmployeeStatusModel()
                {
                    Id = 1
                };

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _okAddResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с пустой датой окончания медкнижки, если выставлен флаг что она есть
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_MedicalBookEndNotNullIfIsHaveMedicalBook()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.IsHaveMedicalBook = true;
                userModel.MedicalBookEnd = null;

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление пользователя с проверкой что добавился
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_User()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _okAddResult);

                var id = (result as OkNegotiatedContentResult<int>).Content;

                var getByIdResult = await controller.GetById(id);

                var addUserModel = (getByIdResult as OkNegotiatedContentResult<IApplicationUserModel>).Content;

                Assert.IsNotNull(addUserModel);
                Assert.IsTrue(addUserModel.EmployeeStatus.Id == 1);
                Assert.IsTrue(addUserModel.Position.Id == 1);
                Assert.IsTrue(addUserModel.Department.Id == 1);

                var isExistResult = await controller.IsExistUserName(new CheckExistUserName() { UserName = userModel.UserName });

                var res = isExistResult as OkNegotiatedContentResult<bool>;

                Assert.IsTrue(res.Content);                
            }
        }

        /// <summary>
        /// Повторное добавление пользователя с одинаковыми логинами
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Add_UserWithDuplicateUserName()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _okAddResult);

                var result2 = await controller.Add(userModel);

                Assert.IsInstanceOfType(result2, _errrorResult);
            }
        }

        #endregion

        #region Обновление пользователя 

        /// <summary>
        /// Обновление пользователя с пустым логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_FirstNameIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.FirstName = string.Empty;

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с пустой фамилией
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_LastNameIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.LastName = string.Empty;

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с пустым паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PasswordIsNull()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.Password = string.Empty;

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с несовпадаюшим паролем
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PasswordNotConfirm()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();
                userModel.ConfirmPassword += "111";

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с не существующим Id должности
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_PositionNotExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.Position = new PositionModel()
                {
                    Id = Int32.MaxValue
                };

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с не существующим Id статуса
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_EmployeeStatusNotExist()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.EmployeeStatus = new EmployeeStatusModel()
                {
                    Id = Int32.MaxValue
                };

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя с пустой датой окончания медкнижки, если выставлен флаг что она есть
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_MedicalBookEndNotNullIfIsHaveMedicalBook()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.IsHaveMedicalBook = true;
                userModel.MedicalBookEnd = null;

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_User()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                userModel.Id = (addResult as OkNegotiatedContentResult<int>).Content;

                Assert.IsNotNull(userModel);

                userModel.LastName = Guid.NewGuid().ToString().Replace("-", "");

                var result = await controller.Update(userModel);

                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        /// <summary>
        /// Обновление пользователя с существующим логином
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Update_UserWithDuplicateUserName()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                var allResult = await controller.Get(1, 10);
                var allUsers = allResult as OkNegotiatedContentResult<PagedResult<IApplicationUserModel>>;
                var userModel2 =
                    allUsers.Content.Data.Find(u => u.UserName != userModel.UserName) as ApplicationUserModel;

                userModel2.UserName = userModel.UserName;

                var result = await controller.Add(userModel);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        #endregion

        #region Удаление пользователя

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_UserNotExist()
        {
            using (var controller = GetController())
            {
                var result = await controller.Delete(Int32.MaxValue);

                Assert.IsInstanceOfType(result, _errrorResult);
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

                var result = await controller.IsCanDelete(platformModel.User.Id);

                Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<bool>));

                var res = (result as OkNegotiatedContentResult<bool>).Content;

                Assert.IsFalse(res);
            }
        }

        /// <summary>
        /// Удаление пользователя запрещено, если есть площадка с этим пользователм
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete_ForExistPlatform2()
        {
            using (var controller = GetController())
            {
                var platformTest = new PlatformControllerTest();
                platformTest.SetupContext();

                var platformId = platformTest.PlatformTest_Add().Result;
                var platformModel = await _platformService.GetByIdAsync(platformId);

                var result = await controller.Delete(platformModel.User.Id);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [TestMethod]
        public async Task AccountTest_Delete()
        {
            using (var controller = GetController())
            {
                var userModel = GetApplicationUserModel();

                var addResult = await controller.Add(userModel);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                var id = (addResult as OkNegotiatedContentResult<int>).Content;

                var result = await controller.Delete(id);

                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
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
                Department = new DepartmentModel()
                {
                    Id = 1,
                    Value = "DepartmentModel"
                },
                DateStart = DateTime.Now,
                UserName = "login" + Guid.NewGuid().ToString().Replace("-", ""),
                Password = "_Aa123456",
                ConfirmPassword = "_Aa123456",
            };
        }

        /// <summary>
        /// Создание контроллера
        /// </summary>
        /// <returns></returns>
        private AccountsController GetController()
        {
            lock (_okAddResult)
            {
                var service = new AccountService(new UnitOfWork(), new AccountValidator());
                return new AccountsController(service);
            }
        }

        #endregion
    }
}
