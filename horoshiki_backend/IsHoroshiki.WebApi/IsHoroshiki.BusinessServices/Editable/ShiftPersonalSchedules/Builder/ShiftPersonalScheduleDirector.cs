using IsHoroshiki.BusinessEntities.Editable.ShiftPersonalSchedules.Tables;

namespace IsHoroshiki.BusinessServices.Editable.ShiftPersonalSchedules.Builder
{
    /// <summary>
    /// Распорядитель. Создает отчет
    /// </summary>
    internal class ShiftPersonalScheduleDirector
    {
        /// <summary>
        /// Базовый класс таблицы графика
        /// </summary>
        private readonly ShiftPersonalScheduleBulder _builder;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="builder">Базовый класс таблицы графикаа</param>
        public ShiftPersonalScheduleDirector(ShiftPersonalScheduleBulder builder)
        {
            this._builder = builder;
        }

        /// <summary>
        /// Создать график
        /// </summary>
        public IShiftPersonalScheduleTableModel CreateTable()
        {
            this._builder.Begin();
            this._builder.CreateEmptyTable();
            this._builder.FillHeaderColumns();
            this._builder.FillSalePlanColumns();
            this._builder.FillPositionColumns();
            this._builder.FillUserCellColumns();
            this._builder.FillShiftCountColumns();
            this._builder.End();

            return this._builder.GetResult();
        }
    }
}
