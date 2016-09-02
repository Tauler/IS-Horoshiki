using IsHoroshiki.BusinessServices.Errors.Enums;

namespace IsHoroshiki.BusinessServices.Errors
{
    /// <summary>
    /// Регистрация сообщений
    /// </summary>
    public class MessageRegister
    {
        /// <summary>
        /// Регистрация кодов ошибок
        /// </summary>
        public static void FillMessageHolder()
        {
            FillMessageAccountHolder();
            FillMessageSubDivisionHolder();
            FillMessagePlatformHolder();
        }

        #region private

        /// <summary>
        /// Заполнение ошибок для пользователя
        /// </summary>
        private static void FillMessageAccountHolder()
        {
            MessageHolder.Instance.AddMessage(AccountErrors.FirstNameIsNull, ResourceBusinessServices.AccountsController_FirstNameIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.LastNameIsNull, ResourceBusinessServices.AccountsController_LastNameIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.UserNameIsNull, ResourceBusinessServices.AccountsController_UserNameIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.IsHaveMedicalBookMedicalBookEnd, ResourceBusinessServices.AccountsController_IsHaveMedicalBookMedicalBookEnd);
            MessageHolder.Instance.AddMessage(AccountErrors.PasswordIsNull, ResourceBusinessServices.AccountsController_PasswordIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.ConfirmPasswordIsNull, ResourceBusinessServices.AccountsController_ConfirmPasswordIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.PasswordNotEquals, ResourceBusinessServices.AccountsController_PasswordNotEquals);
            MessageHolder.Instance.AddMessage(AccountErrors.UserNotFound, ResourceBusinessServices.AccountsController_UserNotFound);
            MessageHolder.Instance.AddMessage(AccountErrors.PositionIsNull, ResourceBusinessServices.AccountsController_PositionIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.EmployeeStatusIsNull, ResourceBusinessServices.AccountsController_EmployeeStatusIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.PositionRepositoryIsNull, ResourceBusinessServices.AccountsController_PositionRepositoryIsNull);
            MessageHolder.Instance.AddMessage(AccountErrors.EmployeeStatusRepositoryIsNull, ResourceBusinessServices.AccountsController_EmployeeStatusRepositoryIsNull);
        }

        /// <summary>
        /// Заполнение ошибок для подразделений
        /// </summary>
        private static void FillMessageSubDivisionHolder()
        {
            MessageHolder.Instance.AddMessage(SubDivisionErrors.NameIsNull, ResourceBusinessServices.Validator_NameIsNull);
            MessageHolder.Instance.AddMessage(SubDivisionErrors.PriceTypeIsNullModel, ResourceBusinessServices.SubDivisionValidator_PriceTypeIsNullModel);
            MessageHolder.Instance.AddMessage(SubDivisionErrors.PriceTypeNotFound, ResourceBusinessServices.SubDivisionService_PriceTypeNotFound);
            MessageHolder.Instance.AddMessage(SubDivisionErrors.TimezoneInvalidPeriod, ResourceBusinessServices.SubDivisionValidator_TimezoneInvalidPeriod);
            MessageHolder.Instance.AddMessage(SubDivisionErrors.TimezoneIsNull, ResourceBusinessServices.SubDivisionValidator_TimezoneIsNull);
        }

        /// <summary>
        /// Заполнение ошибок для платформ
        /// </summary>
        private static void FillMessagePlatformHolder()
        {
            MessageHolder.Instance.AddMessage(PlatformErrors.NameIsNull, ResourceBusinessServices.Validator_NameIsNull);
            MessageHolder.Instance.AddMessage(PlatformErrors.BuyProcessesIsNullModel, ResourceBusinessServices.PlatformValidator_BuyProcessesIsNullModel);
            MessageHolder.Instance.AddMessage(PlatformErrors.MinChecksIsNull, ResourceBusinessServices.PlatformValidator_MinChecksIsNull);
            MessageHolder.Instance.AddMessage(PlatformErrors.PlatformStatusIsNullModel, ResourceBusinessServices.PlatformValidator_PlatformStatusIsNullModel);
            MessageHolder.Instance.AddMessage(PlatformErrors.SubDivisionIsNullModel, ResourceBusinessServices.PlatformValidator_SubDivisionIsNullModel);
            MessageHolder.Instance.AddMessage(PlatformErrors.TimeEndIsNullModel, ResourceBusinessServices.PlatformValidator_TimeEndIsNullModel);
            MessageHolder.Instance.AddMessage(PlatformErrors.TimeStartIsNullModel, ResourceBusinessServices.PlatformValidator_TimeStartIsNullModel);
            MessageHolder.Instance.AddMessage(PlatformErrors.PlatformStatusNotFound, ResourceBusinessServices.PlatformService_PlatformStatusNotFound);
            MessageHolder.Instance.AddMessage(PlatformErrors.SubDivisionNotFound, ResourceBusinessServices.PlatformService_SubDivisionNotFound);
            MessageHolder.Instance.AddMessage(PlatformErrors.UserNotFound, ResourceBusinessServices.PlatformService_UserNotFound);
            MessageHolder.Instance.AddMessage(PlatformErrors.BuyProcessNotFound, ResourceBusinessServices.PlatformService_BuyProcessNotFound);
        }

        #endregion
    }
}
