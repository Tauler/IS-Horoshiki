namespace IsHoroshiki.BusinessServices.Errors.Enums
{
    /// <summary>
    /// Список ошибок для пользователя
    /// </summary>
    public enum AccountErrors
    {
        /// <summary>
        /// Ошибка при добалении пользователя!
        /// </summary>
        AddException,

        /// <summary>
        /// Необходимо указать имя!
        /// </summary>
        FirstNameIsNull,

        /// <summary>
        /// Необходимо указать фамилию!
        /// </summary>
        LastNameIsNull,

        /// <summary>
        /// Необходимо указать логин!
        /// </summary>
        UserNameIsNull,

        /// <summary>
        /// Указано наличие мед. книжки, но не указана дата окончания мед. книжки!
        /// </summary>
        IsHaveMedicalBookMedicalBookEnd,

        /// <summary>
        /// Пароль не должен быть пустым!
        /// </summary>
        PasswordIsNull,

        /// <summary>
        /// Необходимо указать подтверждение пароля!
        /// </summary>
        ConfirmPasswordIsNull,

        /// <summary>
        /// Пароль и подтверждение пароля не совпадают!
        /// </summary>
        PasswordNotEquals,

        /// <summary>
        /// Пользователь не найден!
        /// </summary>
        UserNotFound,

        /// <summary>
        /// Необходимо указать должность!
        /// </summary>
        PositionIsNull,

        /// <summary>
        /// Необходимо указать статус сотрудника!
        /// </summary>
        EmployeeStatusIsNull,

        /// <summary>
        /// Должности для указанного ID={0} не существует!
        /// </summary>
        PositionRepositoryIsNull,

        /// <summary>
        /// Статуса сотрудника для указанного ID={0} не существует!
        /// </summary>
        EmployeeStatusRepositoryIsNull,

        /// <summary>
        /// Необходимо указать площадку!
        /// </summary>
        PlatformIsNull,

        /// <summary>
        /// Площадки для указанного ID={0} не существует!
        /// </summary>
        PlatformRepositoryIsNull,

        /// <summary>
        /// Невозможно удалить пользователя, т.к. он привязан к платформе!
        /// </summary>
        CanNotDeleteExistPlatform,

        /// <summary>
        /// Департамента для указанного ID={0} не существует!
        /// </summary>
        DepartmentRepositoryIsNull
    }
}
