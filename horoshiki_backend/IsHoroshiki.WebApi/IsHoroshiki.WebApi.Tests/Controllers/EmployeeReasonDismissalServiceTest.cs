using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHoroshiki.BusinessServices.Errors;
using IsHoroshiki.BusinessServices.Editable;
using IsHoroshiki.DAO.UnitOfWorks;
using IsHoroshiki.BusinessServices.Validators.Editable;
using IsHoroshiki.WebApi.Handlers;
using System.Web.Http.Results;
using System.Threading.Tasks;
using IsHoroshiki.WebApi.Controllers.Editable;
using IsHoroshiki.BusinessEntities.Editable.Interfaces;
using IsHoroshiki.BusinessEntities.Editable;

namespace IsHoroshiki.WebApi.Tests.Controllers
{
    [TestClass]
    public class EmployeeReasonDismissalServiceTest
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

        #endregion

        [TestInitialize]
        public void SetupContext()
        {
            MessageRegister.FillMessageHolder();
        }

        #region Добавление 

        /// <summary>
        /// Добавление с пустым именем
        /// </summary>
        [TestMethod]
        public async Task EmployeeReasonDismissalService_Add_NameIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();

                model.Name = string.Empty;

                var result = await controller.Add(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        #endregion

        #region Обновление 

        /// <summary>
        /// Обновление с пустым именем
        /// </summary>
        [TestMethod]
        public async Task EmployeeReasonDismissalService_Update_FirstNameIsNull()
        {
            using (var controller = GetController())
            {
                var model = GetModel();

                var addResult = await controller.Add(model);

                Assert.IsInstanceOfType(addResult, _okAddResult);

                model.Name = string.Empty;

                var result = await controller.Update(model);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }

        #endregion

        #region Удаление

        /// <summary>
        /// Удаление 
        /// </summary>
        [TestMethod]
        public async Task EmployeeReasonDismissalService_Delete_UserNotExist()
        {
            using (var controller = GetController())
            {
                var result = await controller.Delete(Int32.MaxValue);

                Assert.IsInstanceOfType(result, _errrorResult);
            }
        }


        /// <summary>
        /// Удаление пользователя
        /// </summary>
        [TestMethod]
        public async Task EmployeeReasonDismissalService_Delete()
        {
            using (var controller = GetController())
            {
                var model = GetModel();

                var addResult = await controller.Add(model);

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
        private IEmployeeReasonDismissalModel GetModel()
        {
            return new EmployeeReasonDismissalModel()
            {
                Name = "Name" + Guid.NewGuid(),
            };
        }

        /// <summary>
        /// Создание контроллера
        /// </summary>
        /// <returns></returns>
        private EmployeeReasonDismissalsController GetController()
        {
            lock (_okAddResult)
            {
                var service = new EmployeeReasonDismissalService(new UnitOfWork(), new EmployeeReasonDismissalValidator());
                return new EmployeeReasonDismissalsController(service);
            }
        }

        #endregion
    }
}
