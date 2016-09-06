using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHoroshiki.WebApi.Controllers.Editable;
using IsHoroshiki.BusinessServices.Editable.Interfaces;
using System.Threading.Tasks;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable;
using System;
using IsHoroshiki.BusinessEntities.NotEditable;
using IsHoroshiki.BusinessEntities.Account;
using System.Web.Http.Results;
using System.Collections.ObjectModel;
using IsHoroshiki.BusinessEntities.NotEditable.Interfaces;
using System.Linq;
using IsHoroshiki.BusinessEntities.Paging;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Validators.Editable;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.WebApi.Handlers;

namespace IsHoroshiki.WebApi.Tests.Controllers
{
    /// <summary>
    /// Тест площадок
    /// </summary>
    [TestClass]
    public class PlatformControllerTest
    {
        #region поля и свойства

        private const int defaultBuyProcessModelModelId1 = 1;
        private const int defaultBuyProcessModelModelId2 = 2;
        private const int defaultPlatformStatusModelId = 1;
        private int defaultUserModelId = 1;

        private ISubDivisionService subDivisionService;
        private IAccountService accountService;

        /// <summary>
        /// Тип результат при удачном добавлении объекта
        /// </summary>
        private readonly Type _okAddResult = typeof(OkNegotiatedContentResult<int>);

        /// <summary>
        /// Тип результат при не удачном добавлении\обновлении\удалении объекта
        /// </summary>
        private readonly Type _errrorResult = typeof(ErrorMessageResult);

        #endregion

        [TestInitialize]
        public void SetupContext()
        {
            MessageRegister.FillMessageHolder();

            subDivisionService = new SubDivisionService(new UnitOfWork(), new SubDivisionValidator());
            accountService = new AccountService(new UnitOfWork(), new AccountValidator());


            var pageUser = accountService.GetAllAsync(1, 1).Result;
            if (pageUser.Data.Count == 0)
            {
                Assert.Fail("Не создан пользователь!");
            }

            defaultUserModelId = pageUser.Data.First().Id;
        }

        #region добавление 

        /// <summary>
        /// Добавление с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_NameIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.Name = string.Empty;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление с миниальным чеком =0
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_MinCheckIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.MinCheck = 0;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление с пустым временем начала открытия
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_TimeStartIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.TimeStart = TimeSpan.Zero;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление с пустым временем закрытия
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_TimeEndIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.TimeEnd = TimeSpan.Zero;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_BuyProcessesIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.BuyProcessesModel = null;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.BuyProcessesModel = new Collection<IBuyProcessModel>()
                {
                    new BuyProcessModel { Id = 1 },
                    new BuyProcessModel { Id = Int32.MaxValue }
                };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.BuyProcessesModel = new Collection<IBuyProcessModel>()
                {
                    new BuyProcessModel { Id = 0 },
                };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_PlatformStatusIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.PlatformStatusModel = null;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.PlatformStatusModel = new PlatformStatusModel { Id = Int32.MaxValue };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.PlatformStatusModel = new PlatformStatusModel { Id = 0 };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_SubDivisionIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.SubDivisionModel = null;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.SubDivisionModel = new SubDivisionModel { Id = Int32.MaxValue };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.SubDivisionModel = new SubDivisionModel { Id = 0 };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление без пользователя
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Add_UserModelIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();
                model.UserModel = null;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.UserModel = new UserModel { Id = Int32.MaxValue };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.UserModel = new UserModel { Id = 0 };

                result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление
        /// </summary>
        [TestMethod]
        public async Task<int> PlatformTest_Add()
        {
            var controller = GetController();

            var model = GetModel();

            var pageDivision = await subDivisionService.GetAllAsync(1, 1);
            if (pageDivision.Data.Count == 0)
            {
                await new SubDivisionControllerTest().SubDivisionTest_Add();
            }

            pageDivision = await subDivisionService.GetAllAsync(1, 1);
            if (pageDivision.Data.Count == 0)
            {
                Assert.Fail("Не созданo подразделение!");
            }

            var savedDivision = pageDivision.Data.First();
            model.SubDivisionModel = savedDivision;

            var pageUser = await accountService.GetAllAsync(1, 1);
            if (pageUser.Data.Count == 0)
            {
                Assert.Fail("Не создан пользователь!");
            }

            model.UserModel = new UserModel
            {
                Id = pageUser.Data.First().Id
            };

            var result = await controller.Add(model);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<int>));

            var id = (result as OkNegotiatedContentResult<int>).Content;

            var getResult = await controller.GetById(id);

            Assert.IsInstanceOfType(getResult, typeof(OkNegotiatedContentResult<IPlatformModel>));

            var savedModel = (getResult as OkNegotiatedContentResult<IPlatformModel>).Content;

            Assert.IsTrue(savedModel.PlatformStatusModel.Id == defaultPlatformStatusModelId);
            Assert.IsTrue(savedModel.SubDivisionModel.Id == savedDivision.Id);
            Assert.IsTrue(savedModel.UserModel.Id == defaultUserModelId);
            Assert.IsTrue(savedModel.BuyProcessesModel.Count == 2);
            Assert.IsTrue(savedModel.BuyProcessesModel.ToList().Any(s => s.Id == defaultBuyProcessModelModelId1 || s.Id == defaultBuyProcessModelModelId2));

            return id;
        }

        #endregion

        #region обновление 

        /// <summary>
        /// Обновление с пустым наименованием
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_NameIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.Name = string.Empty;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Добавление с миниальным чеком =0
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_MinCheckIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.MinCheck = 0;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление с пустым временем начала открытия
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_UpdateTimeStartIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.TimeStart = TimeSpan.Zero;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление с пустым временем закрытия
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_TimeEndIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.TimeEnd = TimeSpan.Zero;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_BuyProcessesIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.BuyProcessesModel = null;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.BuyProcessesModel = new Collection<IBuyProcessModel>()
                {
                    new BuyProcessModel { Id = 1 },
                    new BuyProcessModel { Id = Int32.MaxValue }
                };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.BuyProcessesModel = new Collection<IBuyProcessModel>()
                {
                    new BuyProcessModel { Id = 0 },
                };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_PlatformStatusIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.PlatformStatusModel = null;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.PlatformStatusModel = new PlatformStatusModel { Id = Int32.MaxValue };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.PlatformStatusModel = new PlatformStatusModel { Id = 0 };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление без списка способов покупки
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_SubDivisionIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.SubDivisionModel = null;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.SubDivisionModel = new SubDivisionModel { Id = Int32.MaxValue };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.SubDivisionModel = new SubDivisionModel { Id = 0 };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление без пользователя
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update_UserModelIsNull()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                model.UserModel = null;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.UserModel = new UserModel { Id = Int32.MaxValue };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);

                model.UserModel = new UserModel { Id = 0 };

                result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Обновление
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Update()
        {
            using (var controller = GetController())
            {
                var model = await PlatformTest_AddAndGet();

                var pageDivision = await GetSubDivisionModel();
                if (pageDivision.Data.Count == 0)
                {
                    Assert.Fail("Не созданo подразделение!");
                }

                var savedDivision = pageDivision.Data.First();
                model.SubDivisionModel = savedDivision;

                model.UserModel = new UserModel
                {
                    Id = defaultUserModelId
                };

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, typeof(OkResult));

                var getResult = await controller.GetById(model.Id);

                Assert.IsInstanceOfType(getResult, typeof(OkNegotiatedContentResult<IPlatformModel>));

                var savedModel = (getResult as OkNegotiatedContentResult<IPlatformModel>).Content;

                Assert.IsTrue(savedModel.PlatformStatusModel.Id == defaultPlatformStatusModelId);
                Assert.IsTrue(savedModel.SubDivisionModel.Id == savedDivision.Id);
                Assert.IsTrue(savedModel.UserModel.Id == defaultUserModelId);
                Assert.IsTrue(savedModel.BuyProcessesModel.Count == 2);
                Assert.IsTrue(savedModel.BuyProcessesModel.ToList().Any(s => s.Id == defaultBuyProcessModelModelId1 || s.Id == defaultBuyProcessModelModelId2));
            }
        }

        #endregion

        #region Удаление

        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Delete_NotExist()
        {
            using (var controller = GetController())
            {
                var result = await controller.Delete(Int32.MaxValue);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        /// <summary>
        /// Удаление
        /// </summary>
        [TestMethod]
        public async Task PlatformTest_Delete()
        {
            using (var controller = GetController())
            {
                var getAllResult = await controller.Get(1, 1);

                Assert.IsInstanceOfType(getAllResult, typeof(OkNegotiatedContentResult<PagedResult<IPlatformModel>>));

                var pageAllResult = (getAllResult as OkNegotiatedContentResult<PagedResult<IPlatformModel>>).Content;

                if (pageAllResult.Data.Count == 0)
                {
                    return;
                }

                var model = pageAllResult.Data.First();

                var result = await controller.Delete(model.Id);

                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        #endregion

        #region private

        /// <summary>
        /// Создание 
        /// </summary>
        private IPlatformModel GetModel()
        {
            return new PlatformModel()
            {
                Name = "Name" + Guid.NewGuid().ToString().Replace("-", ""),
                Address = "Address" + Guid.NewGuid().ToString().Replace("-", ""),
                MinCheck = 50,
                TimeStart = new TimeSpan(8, 0, 0),
                TimeEnd = new TimeSpan(20, 0, 0),
                YandexMap = string.Empty,
                BuyProcessesModel = new Collection<IBuyProcessModel> { new BuyProcessModel { Id = defaultBuyProcessModelModelId1 }, new BuyProcessModel { Id = defaultBuyProcessModelModelId2 } },
                PlatformStatusModel = new PlatformStatusModel { Id = defaultPlatformStatusModelId },
                SubDivisionModel = new SubDivisionModel { Id = 1 },
                UserModel = new UserModel { Id = defaultUserModelId, UserName = "testtesttest" }
            };
        }

        /// <summary>
        /// Добавление
        /// </summary>
        [TestMethod]
        public async Task<int> PlatformTest_AddInternal()
        {
            using (var controller = GetController())
            {
                var model = GetModel();

                var pageDivision = await GetSubDivisionModel();
                if (pageDivision.Data.Count == 0)
                {
                    await new SubDivisionControllerTest().SubDivisionTest_Add();
                    pageDivision = await GetSubDivisionModel();
                }

                if (pageDivision.Data.Count == 0)
                {
                    Assert.Fail("Не созданo подразделение!");
                }

                var savedDivision = pageDivision.Data.First();
                model.SubDivisionModel = savedDivision;

                model.UserModel = new UserModel
                {
                    Id = defaultUserModelId
                };

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<int>));

                var id = (result as OkNegotiatedContentResult<int>).Content;

                return id;
            }
        }

        /// <summary>
        /// Добавить и вернуть его из БД
        /// </summary>
        /// <returns></returns>
        private async Task<IPlatformModel> PlatformTest_AddAndGet()
        {
            using (var controller = GetController())
            {

                var id = await PlatformTest_AddInternal();

                var getResult = await controller.GetById(id);

                Assert.IsInstanceOfType(getResult, typeof(OkNegotiatedContentResult<IPlatformModel>));

                return (getResult as OkNegotiatedContentResult<IPlatformModel>).Content;
            }
        }

        private PagedResult<ISubDivisionModel> _subDivisionPagedResult;
        private async Task<PagedResult<ISubDivisionModel>> GetSubDivisionModel()
        {
            if (_subDivisionPagedResult != null && _subDivisionPagedResult.Data.Count == 0)
            {
                _subDivisionPagedResult = null;
            }

            return _subDivisionPagedResult ?? (_subDivisionPagedResult = await subDivisionService.GetAllAsync(1, 1));
        }

        /// <summary>
        /// Создание контроллера
        /// </summary>
        /// <returns></returns>
        private PlatformsController GetController()
        {
            lock (_okAddResult)
            {
                var service = new PlatformService(new UnitOfWork(), new PlatformValidator());
                return new PlatformsController(service);
            }
        }

        #endregion
    }
}
